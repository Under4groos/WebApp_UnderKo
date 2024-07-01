using WebApp_UnderKo.Models.IO;
using WebApp_UnderKo.Models.Serializator.Xaml;
using WebApp_UnderKo.Models.XamlProjectObject.Project;
namespace WebApp_UnderKo.Models
{
    public static class StartupServerOptions
    {

        public static async Task InitFiles()
        {
            /////////////////////////////////////////////////////
            ///
            if (!InputOutput.PATH_BASE_LocalRead(@"__githubapi.key.txt",
                (string result) =>
                {
                    G_.git.API_KEY = result.Trim();
                    // null 
                }, true).Result)
            {
                await InputOutput.PATH_BASE_LocalWriteAsync(@"__githubapi.key.txt", "<apikey>");
            };

            /////////////////////////////////////////////////////



            /////////////////////////////////////////////////////
            ///
            if (!InputOutput.PATH_BASE_LocalRead(@"__myprojects.html",
                (string result) =>
                {
                    G_.CacheData.xamlProjectsData = G_.ProjectsData_Serializator.xaml_XamlProject_Serializator.DeserializeObject(result);
                }, true).Result)
            {
                G_.CacheData.xamlProjectsData.__init_null();
                string xaml_obj_string = new XamlSerializator<XamlProjectsData>().SerializeObject(G_.CacheData.xamlProjectsData);
                await InputOutput.PATH_BASE_LocalWriteAsync(@"__myprojects.html", xaml_obj_string);
            };

            /////////////////////////////////////////////////////

            if (!InputOutput.PATH_BASE_LocalRead(@"__apilist.html",
                (string result) =>
                {
                    G_.CacheData.apiList = G_.ApiList_Serializator.DeserializeObject(result);

                }, true).Result)
            {
                G_.CacheData.apiList.__init_null();
                string xaml_obj_string = G_.ApiList_Serializator.SerializeObject(G_.CacheData.apiList);
                await InputOutput.PATH_BASE_LocalWriteAsync(@"__apilist.html", xaml_obj_string);
            };

            /////////////////////////////////////////////////////




        }

        public static async Task<bool> Init()
        {
            G_.logger.NewLine("Loading StartupServerOptions");

            await InitFiles();
            G_.git.Event_AppendItemsRepositories += () =>
            {
                G_.logger.NewLine($"Repositories loaded. Count projects: {G_.git.GitHubReposList.Count}");
            };

            G_.git.Init_Profile("Under4groos");
            G_.git.GetRepositories("Under4groos");

            InputOutput.CreateFolders(G_.CacheData.PATH_WWWROOT, G_.CacheData.OpenDirectories);



            return false;
        }
    }
}
