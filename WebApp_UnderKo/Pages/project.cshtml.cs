using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Components.api;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.XamlProjectObject.Project;

namespace WebApp_UnderKo.Pages
{
    public class projectModel : PageModel
    {
        public string NameProject = string.Empty;
        public XamlProject project { get; set; }
        public List<Button> BUTTONS_TOP = new List<Button>();
        public async Task<IActionResult> OnGet(string name = "", bool reopen = false)
        {

            this.Init();

            NameProject = name;

            if (!string.IsNullOrEmpty(NameProject))
            {
                var projects_ = (from pro in G_.CacheData.xamlProjectsData.Projects where NameProject == pro.Name select pro);
                int count_ = projects_.Count();
                if (count_ == 0)
                    return this.Redirect("/project");

                project = projects_.First();
                BUTTONS_TOP = project.ButtonsTop;

                if (project.Downloads == 0 && !string.IsNullOrEmpty(project.GitHubLinkReleases))
                {
                    dynamic? obj = await GitApiController.__GetProject(project.GitHubLinkReleases);

                    if (obj != null)
                        if (obj[0] != null)
                        {

                            string url_zip = obj[0]["assets"][0]["browser_download_url"];

                            for (int i = 0; i < BUTTONS_TOP.Count; i++)
                            {
                                BUTTONS_TOP[i].Command = BUTTONS_TOP[i].Command.Trim();
                                if (BUTTONS_TOP[i].Command == "_LINK_GIT_")
                                    BUTTONS_TOP[i].Command = $"window.open('{url_zip}','_blank');";
                            }
                            //foreach (var item in BUTTONS_TOP)
                            //{
                            //    item.Command.Replace("_LINK_GIT_", url_zip);
                            //}

                            foreach (var asset in obj)
                            {

                                foreach (var item in asset["assets"])
                                {
                                    project.Downloads += (int)item["download_count"];

                                }
                            }

                        }


                }


            }


            return this.Page();
        }
    }
}
