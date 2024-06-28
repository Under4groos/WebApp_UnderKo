using WebApp_UnderKo.Models.IO;
namespace WebApp_UnderKo.Models
{
    public static class StartupServerOptions
    {


        public static async Task<bool> Init()
        {
            G_.logger.NewLine("Loading StartupServerOptions");



            if (!InputOutput.PATH_BASE_LocalRead(@"Data\__githubapi.key.txt",
                (string result) =>
                {
                    G_.logger.NewLine($"{result}");
                }, true).Result)
            {
                await InputOutput.PATH_BASE_LocalWriteAsync(@"Data\__githubapi.key.txt", "<apikey>");
            };
            G_.git.Event_AppendItemsRepositories += () =>
            {
                G_.logger.NewLine($"Repositories loaded. Count projects: {G_.git.GitHubReposList.Count}");
            };
            G_.git.Init_Profile("Under4groos");
            G_.git.GetRepositories("Under4groos");

            InputOutput.CreateFolders(G_.CacheData.PATH_WWWROOT, new[] { "files" });



            return false;
        }
    }
}
