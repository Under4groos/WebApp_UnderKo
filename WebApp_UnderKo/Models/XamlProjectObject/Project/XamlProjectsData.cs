using WebApp_UnderKo.Models.XamlProjectObject.Project.Base;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project
{
    public class XamlProjectsData : base_XamlData
    {
        public List<XamlProject> Projects { get; set; } = new List<XamlProject>();


        public void __init_null()
        {
            this.Projects = new List<XamlProject>()
            {
                new XamlProject()
                {
                    Name = "1",
                    Description = "asd",
                    ButtonsTop = new List<Button>()
                    {
                        new Button()
                        {
                            Text = "1",

                        },
                        new Button()
                        {
                            Text = "2",

                        }
                    },
                    YouTubeLinks = {
                        "adsdasd" , "sadasdasdas" , "asdasdasdasdsaadsads"
                    },
                     GitHubLinkReleases = "https://adsadssadadsadsasddsa"
                },
                new XamlProject()
                {
                    Name = "2",

                    Description = "asd",

                },
                new XamlProject()
                {
                    Name = "3",
                    Description = "asd",

                }
            };
        }
    }
}
