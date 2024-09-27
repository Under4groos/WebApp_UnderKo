using System.Diagnostics;
using WebApp_UnderKo.Models.IO;
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
            if (!InputOutput.PATH_BASE_LocalRead(@"__myprojects.json",
                (string result) =>
                {

                    G_.CacheData.xamlProjectsData = G_.ProjectsData_Serializator.DeserializeObject(result, Serializator.enumType.json);

                    //string str_json = G_.ProjectsData_Serializator.json_XamlProject_Serializator.SerializeObject(G_.CacheData.xamlProjectsData);
                    //str_json = str_json.Replace("\\n", "");
                    //File.WriteAllText(@"__myprojects.json", str_json);

                }, true).Result)
            {
                G_.CacheData.xamlProjectsData.__init_null();
                string xaml_obj_string = G_.ProjectsData_Serializator.json_XamlProject_Serializator.SerializeObject(G_.CacheData.xamlProjectsData);
                await InputOutput.PATH_BASE_LocalWriteAsync(@"__myprojects.json", xaml_obj_string);
            };

            /////////////////////////////////////////////////////

            if (!InputOutput.PATH_BASE_LocalRead(@"__apilist.html",
                (string result) =>
                {
                    G_.CacheData.apiList = G_.ApiList_Serializator.DeserializeObject(result, Serializator.enumType.xaml);

                }, true).Result)
            {
                G_.CacheData.apiList.__init_null();
                string xaml_obj_string = G_.ApiList_Serializator.SerializeObject(G_.CacheData.apiList, Serializator.enumType.xaml);
                await InputOutput.PATH_BASE_LocalWriteAsync(@"__apilist.html", xaml_obj_string);
            };

            /////////////////////////////////////////////////////

            if (!InputOutput.PATH_BASE_LocalRead(@"__Pinterest.txt",
                (string result) =>
                {
                    G_.CacheData.Pinterest.cookie = result;

                }, true).Result)
            {


                await InputOutput.PATH_BASE_LocalWriteAsync(@"__Pinterest.txt", "<null>");
            };



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
            //G_.git.GetRepositories("Under4groos");

            InputOutput.CreateFolders(G_.CacheData.PATH_WWWROOT, G_.CacheData.OpenDirectories);



            new Thread(() =>
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo = new ProcessStartInfo()
                    {
                        FileName = "py \"/home/init.py\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    //while (process.StandardOutput.EndOfStream)
                    //{
                    //    string output = process.StandardOutput.ReadToEnd();
                    //    G_.HTOP_DataConseole = output ?? "null";
                    //}
                    process.OutputDataReceived += (o, e) =>
                    {

                        if (string.IsNullOrEmpty(e.Data))
                            G_.HTOP_DataConseole = "";
                        G_.HTOP_DataConseole += e.Data ?? "null";
                    };
                    process.WaitForExit();
                }
                catch (Exception e)
                {
                    G_.logger.NewLine($"{e.Message}", Log.ELoggerExtensions.Error);
                    while (true)
                    {
                        Thread.Sleep(1500);
                        G_.HTOP_DataConseole = G_.Random.Next(0, 999).ToString();
                    }

                }
            }).Start();


            return false;
        }
    }
}
