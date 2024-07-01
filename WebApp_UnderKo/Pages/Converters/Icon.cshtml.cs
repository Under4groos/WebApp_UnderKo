using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Pages.Converters
{
    public class IconModel : base_CheckPage
    {
        public string download_link = string.Empty;
        public void OnGet(string guid = null)
        {
            this.Init();
            if (guid != null)
            {
                download_link = $"/file?name={guid}";
            }

        }
    }
}
