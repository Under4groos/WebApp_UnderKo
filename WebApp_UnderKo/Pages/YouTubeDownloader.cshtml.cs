using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Components.api;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.YouTube;

namespace WebApp_UnderKo.Pages
{
    public class YouTubeDownloaderModel : PageModel
    {
        public YouTubeDownloaderLinks YouTubeDownloaderLinks_ = new YouTubeDownloaderLinks();
        public string Link { get; set; }
        public void OnGet(string link = "")
        {
            this.Init();
            if (!string.IsNullOrEmpty(link))
            {
                YouTubeDownloaderLinks_ = new YouTubeApiController().__get(link).Result;
                Link = link;
            }


        }
        public ActionResult OnPost(string url)
        {
            return this.Redirect($"/YouTubeDownloader?link={url}");

        }
    }
}
