using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp_UnderKo.Pages.Converters
{
    public class IconModel : PageModel
    {
        public string download_link = string.Empty;
        public void OnGet(string guid = null)
        {

            if (guid != null)
            {
                download_link = $"/api/file?name={guid}";
            }

        }
    }
}
