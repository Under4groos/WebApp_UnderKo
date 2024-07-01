using System.Xml.Serialization;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project.Base
{
    public class base_XamlProject : base_XamlData
    {
        [XmlAttribute]
        public string Name { get; set; } = string.Empty;
        public int Downloads { get; set; } = 0;
        public string Description { get; set; } = string.Empty;

        public string GitHubLinkReleases { get; set; } = string.Empty;

        public List<string> Images { get; set; } = new List<string>();

        public List<string> YouTubeLinks { get; set; } = new List<string>();

        public object JSON_OBJECT_GIT = null;
    }
}
