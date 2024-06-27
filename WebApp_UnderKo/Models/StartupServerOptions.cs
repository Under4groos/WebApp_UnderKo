using WebApp_UnderKo.Models.IO;

namespace WebApp_UnderKo.Models
{
    public static class StartupServerOptions
    {


        public static async Task<bool> Init()
        {
            G_.logger.NewLine("Loading StartupServerOptions");



            await InputOutput.ReadAsync(@"C:\Users\UnderKo\Documents\Arduino\AnalogReadSerial\AnalogReadSerial.ino",
                (string result) =>
                {

                });


            InputOutput.CreateFolders(G_.CacheData.PATH_WWWROOT, new[] { "files" });



            return false;
        }
    }
}
