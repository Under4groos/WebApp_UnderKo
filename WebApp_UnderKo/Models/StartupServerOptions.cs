using WebApp_UnderKo.Models.IO;

namespace WebApp_UnderKo.Models
{
    public static class StartupServerOptions
    {
#if DEBUG
        public static void __debug()
        {
            Console.WriteLine("Loading StartupServerOptions");
        }


#endif

        public static async Task<bool> Init()
        {
#if DEBUG
            __debug();
#endif      



            await InputOutput.Read(@"C:\Users\UnderKo\Documents\Arduino\AnalogReadSerial\AnalogReadSerial.ino",
                (string result) =>
                {
                    Console.WriteLine($"{result}");
                });




            return false;
        }
    }
}
