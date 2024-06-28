using WebApp_UnderKo.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
await StartupServerOptions.Init();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
app.Run();
