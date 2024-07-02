namespace WebApp_UnderKo.Models.XamlProjectObject.ApiList
{
    public class WebApi
    {

        public string URL { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> reqQueries { get; set; } = new List<string>();


    }
}
