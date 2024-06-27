using WebApp_UnderKo.Models;

var builder = WebApplication.CreateBuilder(args);




await StartupServerOptions.Init();

builder.Services.AddRazorPages();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{


    endpoints.MapControllers();

});
app.UseAuthorization();
app.Run();
