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



            return false;
        }
    }
}
