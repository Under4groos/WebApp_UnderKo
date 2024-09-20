using System.Diagnostics;
using WebApp_Socket.Models;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, HtopModel_JsonSerializerContext.Default);
});

static void log_add(object obj)
{
    Console.WriteLine(obj);
    Debug.WriteLine(obj);
}

HtopModel htopModel = new HtopModel();

new Thread(() =>
{
    try
    {
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo()
        {
            FileName = "htop",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true,
            RedirectStandardError = true,
        };
        process.OutputDataReceived += (o, e) =>
        {
            htopModel.Data = e.Data ?? "null";

            log_add(htopModel.Data);
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
    }
    catch (Exception e)
    {

        log_add(e.Message);
    }
}).Start();


var app = builder.Build();
app.Map("/", () => "--" + htopModel.Data);

app.Run("http://127.0.0.1:5003");
//var sampleTodos = new Todo[] {
//    new(1, "Walk the dog"),
//    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
//    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
//    new(4, "Clean the bathroom"),
//    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
//};

//var todosApi = app.MapGroup("/todos");
//todosApi.MapGet("/", () => sampleTodos);
//todosApi.MapGet("/{id}", (int id) =>
//    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
//        ? Results.Ok(todo)
//        : Results.NotFound());

//app.Run();

//public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);


