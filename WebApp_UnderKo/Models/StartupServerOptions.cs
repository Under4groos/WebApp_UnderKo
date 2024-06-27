using WebApp_UnderKo.Models.IO;

namespace WebApp_UnderKo.Models
{
    public static class StartupServerOptions
    {


        public static async Task<bool> Init()
        {
            G_.logger.NewLine("Loading StartupServerOptions");



            await InputOutput.PATH_BASE_LocalRead(@"Data\test.txt",
                (string result) =>
                {
                    G_.logger.NewLine($"{result}");
                });


            InputOutput.CreateFolders(G_.CacheData.PATH_WWWROOT, new[] { "files" });



            return false;
        }
    }
}
