using WebApp_UnderKo.Models.XamlProjectObject.Project.Base;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project
{
    public class XamlProjectsData : base_XamlData
    {
        public List<XamlProject> Projects { get; set; } = new List<XamlProject>();


        public void __init_null()
        {
            this.Projects = new List<XamlProject>();



            for (int i = 0; i < 4; i++)
            {
                this.Projects.Add(new XamlProject()
                {
                    Name = G_.RandomGenerateHEX,
                    Description = G_.RandomGenerateHEX,
                    ButtonsTop = new List<Button>()
                    {
                        new Button()
                        {
                            Text = G_.RandomGenerateHEX,
                            Command = G_.RandomGenerateHEX,
                        },
                        new Button()
                        {
                            Text = G_.RandomGenerateHEX,
                            Command = G_.RandomGenerateHEX
                        }
                    },
                    YouTubeLinks = {
                        G_.RandomGenerateHEX,G_.RandomGenerateHEX,G_.RandomGenerateHEX
                    },
                    GitHubLinkReleases = G_.RandomGenerateHEX,
                    Features =
                    {
                        new Feature()
                        {
                             Text = G_.RandomGenerateHEX,
                             Description = G_.RandomGenerateHEX
                        },
                        new Feature()
                        {
                             Text = G_.RandomGenerateHEX,
                             Description = G_.RandomGenerateHEX
                        }
                    },
                    Images =
                    {
                        G_.RandomGenerateHEX , G_.RandomGenerateHEX , G_.RandomGenerateHEX
                    }
                });
            }

        }
    }
}
