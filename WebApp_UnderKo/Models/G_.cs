using Microsoft.AspNetCore.StaticFiles;
using Rijndael256;
using System.Text.RegularExpressions;
using WebApp_UnderKo.Models.GitHub;
using WebApp_UnderKo.Models.Serializator;
using WebApp_UnderKo.Models.XamlProjectObject.ApiList;
using WebApp_UnderKo.Models.XamlProjectObject.Project;

namespace WebApp_UnderKo.Models
{
    public static class G_
    {
        public static Random Random = new Random();
        public static string RandomGenerateHEX
        {
            get
            {
                return Regex.Replace(Rijndael.Encrypt(G_.Random.Next(0, 999999).ToString(), KeySize.Aes256),
                    "[\\W\\+\\-\\.=,;\\[\\]]+",
                    "");
            }
        }


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


        #region console

        public static string HTOP_DataConseole = string.Empty;
        #endregion



    }
}
