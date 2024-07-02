using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.Init();
        }
    }

}
