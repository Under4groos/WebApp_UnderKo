using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Pages.Converters
{
    public class IconModel : PageModel
    {
        public string download_link = string.Empty;
        public void OnGet(string guid = null)
        {
            this.Init();

            if (!string.IsNullOrEmpty(guid))
            {
                guid = guid.Trim();
                if (guid.Length > 10)
                {
                    // http://localhost:7076/files/uploads/r20JbMvTm20zQwCoZODYqcP4EZR4Q7q5AbmwtO50UZGUuc8ubkq7ppYSp55wEQIM0EMCpUKX2yd0lL5snO5g.ico
                    // http://localhost:7076/files/uploads/EcQ8bA3c0NyX1Qo73Jj9cQQeHws7uvpnXOSQrZ3gIeFI7taDd8Mn53d84hI4XsY.ico
                    download_link = $"/files{guid}";
                }

            }
        }
    }
}
