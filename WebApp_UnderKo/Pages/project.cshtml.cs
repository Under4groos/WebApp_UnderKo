using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Pages
{
    public class projectModel : PageModel
    {
        public string NameProject = string.Empty;
        public async void OnGet(string name = "", bool reload = false)
        {
            if (reload)
                await StartupServerOptions.Init();
            NameProject = name;
        }
    }
}
