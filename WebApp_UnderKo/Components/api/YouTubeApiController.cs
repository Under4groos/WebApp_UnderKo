using Microsoft.AspNetCore.Mvc;
using VideoLibrary;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.Mvc;
using WebApp_UnderKo.Models.Mvc.Result;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.YouTube;

namespace WebApp_UnderKo.Components.api
{

    [Route("api/YouTubeApi")]
    [ApiController]
    public class YouTubeApiController : OverControllerBase
    {

        private HttpClient _client = new HttpClient();
        YouTube youTube = YouTube.Default;
        [HttpGet()]
        public async Task<ActionResult> Get(int v = 1, string link = null)
        {
            this.Init();
            if (string.IsNullOrEmpty(link))
                return this.SerializeObject("error");
            string base___ = G_.CacheData.PATH_WWWROOT_FILES;

            try
            {

                var links = await __get(link);
                if (links.LinksYouTubeVideo.Count > 0 || links.LinksYouTubeVideoAudio.Count > 0)
                    switch (v)
                    {
                        case 1:
                            return this.SerializeObject(links);
                        case 2:

                            var video = links.LinksYouTubeVideo.First();

                            var s = await _client.GetStreamAsync(video.Uri);
                            this.File(s, "video/mp4");

                            return Ok(s);
                        case 3:
                            var audio = links.LinksYouTubeVideoAudio.First();
                            var a = await _client.GetStreamAsync(audio.Uri);
                            this.File(a, "audio/mpeg");

                            return Ok(a);
                        default:
                            return NoContent();

                    }


                #region hide
                //if (isone)
                //{
                //    if (links.LinksYouTubeVideo.Count > 0 || links.LinksYouTubeVideoAudio.Count > 0)
                //    {
                //        var video = links.LinksYouTubeVideo.First();
                //        var audio = links.LinksYouTubeVideoAudio.First();
                //        string video_path_ = $"{G_.RandomGenerateHEX}.mp4";
                //        string audio_path_ = $"{G_.RandomGenerateHEX}.mp3";

                //        video_path_ = Path.Combine(base___, video_path_);
                //        audio_path_ = Path.Combine(base___, audio_path_);



                //        var data = video.GetBytesAsync();
                //        byte[] arr_ = data.Result;
                //        System.IO.File.WriteAllBytes(video_path_, arr_);

                //        Console.WriteLine(video_path_);

                //        data = audio.GetBytesAsync();
                //        arr_ = data.Result;
                //        System.IO.File.WriteAllBytes(audio_path_, arr_);

                //        Console.WriteLine(audio_path_);

                //        string marge_path_ = Path.Combine(base___, $"{G_.RandomGenerateHEX}.mp4");
                //        StreamMerge.Merge(video_path_, audio_path_, Path.Combine(base___, marge_path_));

                //        return this.SerializeObject(new { marge_path_, video_path_, audio_path_ });
                //    }


                //    return this.SerializeObject(new { });
                //} 
                #endregion



                _client.Dispose();
            }
            catch (Exception e)
            {

                return new TextResult(new objError($"Processing error", e.Message));
            }


            return this.SerializeObject("opps///");
        }



        public async Task<YouTubeDownloaderLinks> __get(string link)
        {
            if (G_.CacheData.DictionaryYouTubeDownloaderLinks.ContainsKey(link))
                return G_.CacheData.DictionaryYouTubeDownloaderLinks[link];

            var video = youTube.GetAllVideos(link);

            YouTubeDownloaderLinks youTubeDownloaderLinks = new YouTubeDownloaderLinks();

            foreach (YouTubeVideo item in video)
            {
                switch (item.AdaptiveKind)
                {
                    case AdaptiveKind.None:
                        youTubeDownloaderLinks.LinksYouTubeVideoNone.Add(item);
                        break;
                    case AdaptiveKind.Audio:
                        youTubeDownloaderLinks.LinksYouTubeVideoAudio.Add(item);
                        break;
                    case AdaptiveKind.Video:

                        youTubeDownloaderLinks.LinksYouTubeVideo.Add(item);
                        break;
                    default:
                        break;
                }

            }

            G_.CacheData.DictionaryYouTubeDownloaderLinks.Add(link, youTubeDownloaderLinks);



            return youTubeDownloaderLinks;
        }
    }
}
