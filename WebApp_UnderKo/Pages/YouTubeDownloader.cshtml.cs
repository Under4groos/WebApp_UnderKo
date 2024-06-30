using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Components.api;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.YouTube;

namespace WebApp_UnderKo.Pages
{
    public class YouTubeDownloaderModel : base_CheckPage
    {
        public YouTubeDownloaderLinks YouTubeDownloaderLinks_ = new YouTubeDownloaderLinks();
        public string Link { get; set; }
        public void OnGet(string link = "")
        {
            this.Init();
            if (!string.IsNullOrEmpty(link))
            {
                if (link.StartsWith("https://youtu.be/"))
                {
                    link = "https://www.youtube.com/watch?v=" + link.Replace("https://youtu.be/", "").Replace("?", "&");
                }
                if (link.StartsWith("https://www.youtube.com/watch"))
                {
                    Link = link;

                    YouTubeDownloaderLinks_ = new YouTubeApiController().__get(link).Result;

                }


            }

        }
        public ActionResult OnPost(string url)
        {
            return this.Redirect($"/YouTubeDownloader?link={url}");

        }
    }
}
