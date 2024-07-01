using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Pages
{
    public class projectModel : PageModel
    {
        public string NameProject = string.Empty;

        public async Task<IActionResult> OnGet(string name = "")
        {



            await StartupServerOptions.InitFiles();


            NameProject = name;

            if (!string.IsNullOrEmpty(NameProject))
            {
                int count_ = (from pro in G_.CacheData.xamlProjectsData.Projects where NameProject == pro.Name select pro).Count();
                if (count_ == 0)
                    return this.Redirect("/project");
            }


            return this.Page();
        }
    }
}
