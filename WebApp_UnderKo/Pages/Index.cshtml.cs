using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {
            this.Init();
        }
    }
}
