using WebApp_UnderKo.Models.GitHub;
using YoutubeExplode;

namespace WebApp_UnderKo.Models
{
    public static class G_
    {
        public static YoutubeClient youtube = new YoutubeClient();
        public static Cache CacheData = new Cache();
        public static Log.Logger logger = new Log.Logger();
        public static Git git = new Git();
    }
}
