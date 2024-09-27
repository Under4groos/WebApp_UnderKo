using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parser.PinterestMediaLib;
using Parser.PinterestMediaLib.Structures;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Pages
{
    public class PinterestDownloaderModel : PageModel
    {
        public string Link { get; set; }
        public List<Video> LinksVideo = new List<Video>();
        public void OnGet(string link = "")
        {
            link = link.Trim();
            this.Init();
            if (!string.IsNullOrEmpty(link))
            {
                if (G_.CacheData.Pinterest.DictionaryLinksVideo.ContainsKey(link))
                {
                    LinksVideo = G_.CacheData.Pinterest.DictionaryLinksVideo[link];
                    return;
                }

                using (PinParser client = new PinParser())
                {
                    client.DefaultHeaders();
                    client.DefaultRequestHeaders.Add("cookie", G_.CacheData.Pinterest.cookie);
                    client.Parse(link);

                    //client.LinksVideo;
                    LinksVideo = client.LinksVideo;

                    G_.CacheData.Pinterest.DictionaryLinksVideo.Add(link, client.LinksVideo);

                }
                Link = link;
            }


        }

        public ActionResult OnPost(string url)
        {
            return this.Redirect($"/PinterestDownloader?link={url}");

        }
    }
}
