using WebApp_UnderKo.Models.GitHub;
using WebApp_UnderKo.Models.Serializator.Json;
using WebApp_UnderKo.Models.Serializator.Xaml;
using WebApp_UnderKo.Models.XamlProjectObject.ApiList;
using YoutubeExplode;

namespace WebApp_UnderKo.Models
{
    public static class G_
    {
        public static YoutubeClient youtube = new YoutubeClient();
        public static Cache CacheData = new Cache();
        public static Log.Logger logger = new Log.Logger();
        public static Git git = new Git();



        #region SERIALOZATORS
        public static XamlSerializator<ApiList> xaml_ApiList = new XamlSerializator<ApiList>();
        public static JsonSerializator<ApiList> json_ApiList = new JsonSerializator<ApiList>();

        #endregion





    }
}
