using WebApp_UnderKo.Models.IO;
using WebApp_UnderKo.Models.Serializator.Xaml;
using WebApp_UnderKo.Models.XamlProjectObject.Project;
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
                    // null 
                }, true).Result)
            {
                await InputOutput.PATH_BASE_LocalWriteAsync(@"Data\__githubapi.key.txt", "<apikey>");
            };

            if (!InputOutput.PATH_BASE_LocalRead(@"Data\__myprojects.html",
                (string result) =>
                {
                    G_.logger.NewLine($"{result}");
                }, true).Result)
            {
                XamlData xaml_obj = new XamlData();
                xaml_obj.__init_null();
                string xaml_obj_string = new XamlSerializator<XamlData>().SerializeObject(xaml_obj);


                await InputOutput.PATH_BASE_LocalWriteAsync(@"Data\__myprojects.html", xaml_obj_string);
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
