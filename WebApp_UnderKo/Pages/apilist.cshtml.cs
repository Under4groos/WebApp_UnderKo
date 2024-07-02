using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.XamlProjectObject.ApiList;

namespace WebApp_UnderKo.Pages
{
    public class apilistModel : PageModel
    {
        public List<WebApi> webApis { get; set; } = new List<WebApi>();
        public void OnGet()
        {
            this.Init();

        }
    }
}
