using System.Xml.Serialization;
using WebApp_UnderKo.Models.XamlProjectObject.Project.Base;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project
{
    public class Features : base_XamlData
    {
        [XmlAttribute]
        public string Text { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
