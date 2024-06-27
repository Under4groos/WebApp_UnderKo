namespace WebApp_UnderKo.Models
{
    public class CacheData
    {
        public string PATH_WWWROOT = string.Empty;
        public string PATH_WWWROOT_FILES = string.Empty;
        public string[] ImagesBack = { };

        public Dictionary<string, string> Images = new Dictionary<string, string>();
        public Dictionary<string, string> Sound = new Dictionary<string, string>();
        public List<string> LogData = new List<string>();








        public void Reload()
        {
            PATH_WWWROOT = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            PATH_WWWROOT_FILES = Path.Combine(PATH_WWWROOT, "file");
            if (Directory.Exists(PATH_WWWROOT_FILES))
            {
                string[] files___ = Directory.GetFiles(PATH_WWWROOT_FILES, "*.jpg");
                ImagesBack = (from file in files___ select (new FileInfo(file)).Name).ToArray();
            }
        }


    }
}
