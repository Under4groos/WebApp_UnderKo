using Microsoft.AspNetCore.StaticFiles;
using WebApp_UnderKo.Models.GitHub;
using WebApp_UnderKo.Models.Serializator;
using WebApp_UnderKo.Models.XamlProjectObject.ApiList;
using WebApp_UnderKo.Models.XamlProjectObject.Project;
using YoutubeExplode;

namespace WebApp_UnderKo.Models
{
    public static class G_
    {
        public static Random Random = new Random();

        public static YoutubeClient youtube = new YoutubeClient();
        public static Cache CacheData = new Cache();
        public static Log.Logger logger = new Log.Logger();
        public static Git git = new Git();
        public static FileExtensionContentTypeProvider FileExtension = new FileExtensionContentTypeProvider();


        #region SERIALOZATORS
        public static Serializator<ApiList> ApiList_Serializator = new Serializator<ApiList>();
        public static Serializator<WebApi> WebApi_Serializator = new Serializator<WebApi>();
        public static Serializator<XamlProjectsData> ProjectsData_Serializator = new Serializator<XamlProjectsData>();
        public static Serializator<XamlProject> XamlProject_Serializator = new Serializator<XamlProject>();
        #endregion





    }
}
