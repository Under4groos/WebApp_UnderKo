using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.YouTube;

namespace WebApp_UnderKo.Pages
{
    public class YouTubeDownloaderModel : PageModel
    {
        public YouTubeDownloaderLinks YouTubeDownloaderLinks_ = new YouTubeDownloaderLinks();
        public string Link { get; set; }
        public string LinkAudio { get; set; }
        public void OnGet(string link = "")
        {
            this.Init();
            if (!string.IsNullOrEmpty(link))
            {
                //YouTubeDownloaderLinks_ = new YouTubeApiController().__get(link).Result;
                Link = $"/api/YouTubeApi?v=2&link={link}";
                LinkAudio = $"/api/YouTubeApi?v=3&link={link}";


            }


        }
        public ActionResult OnPost(string url)
        {
            return this.Redirect($"/YouTubeDownloader?link={url}");

        }
    }
}
