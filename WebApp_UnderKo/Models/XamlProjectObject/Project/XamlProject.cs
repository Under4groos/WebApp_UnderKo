using WebApp_UnderKo.Models.XamlProjectObject.Project.Base;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project
{
    public class XamlProject : base_XamlProject
    {
        public List<Button> ButtonsTop { get; set; } = new List<Button>();
        public List<Features> Features { get; set; } = new List<Features>();
    }
}
