using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Components.api;
using WebApp_UnderKo.Models;
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

            if (reopen)
                await Models.StartupServerOptions.InitFiles();

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
                    project.Downloads = GitApiController.__GetProjectCountDownload(project.GitHubLinkReleases).Result;

            }


            return this.Page();
        }
    }
}
