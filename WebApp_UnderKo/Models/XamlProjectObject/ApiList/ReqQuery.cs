using System.Xml.Serialization;

namespace WebApp_UnderKo.Models.XamlProjectObject.ApiList
{
    public class ReqQuery
    {
        [XmlAttribute]
        public string Name { get; set; } = string.Empty;
        public string Parametr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
