using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.Mvc.Result;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.Serializator.Json;
using WebApp_UnderKo.Models.YouTube;
using YoutubeExplode.Videos;


namespace WebApp_UnderKo.Components.api
{
    [Route("api/YouTubeApi")]
    [ApiController]
    public class YouTubeApiController : ControllerBase
    {
        YouTubeDownloaderLinks StreamInfoList = new YouTubeDownloaderLinks();

        [HttpGet()]
        public ActionResult Get(string link = null)
        {
            this.Init();
            if (string.IsNullOrEmpty(link))
                return new TextResult(new objError($"Processing error", "Link length: 0"));




            try
            {
                YouTubeDownloaderLinks list_ = __get(link).Result;

                return Content(new JsonSerializator<YouTubeDownloaderLinks>().SerializeObject(list_));

            }
            catch (Exception e)
            {

                return new TextResult(new objError($"Processing error", e.Message));
            }

            // || link.StartsWith("https://youtu.be")
            // https://www.youtube.com/watch?v=KoKDad4Uq9o&list=RDn176EOKDLtg&index=4
            // https://youtu.be/KoKDad4Uq9o?list=RDn176EOKDLtg
            // https://www.youtube.com/watch?v=n176EOKDLtg&list=RDn176EOKDLtg

        }


        public async Task<YouTubeDownloaderLinks> __get(string link)
        {


            VideoId videoId;
            try
            {
                videoId = VideoId.Parse(link);
            }
            catch (Exception)
            {
                StreamInfoList.Clear();
                return StreamInfoList;
            }

            foreach (var Links in G_.CacheData.YouTubeDownloaderLinks)
            {
                if (Links.videoId == videoId)
                    return Links;
            }


            var streamManifest = await G_.youtube.Videos.Streams.GetManifestAsync(videoId);

            // Muxed ///////////////////////////////////////////////////////////////////////

            List<objMuxedStreamInfo> objMuxedStreamInfos = new List<objMuxedStreamInfo>();
            streamManifest.GetMuxedStreams().OrderBy(p => p.VideoResolution.Area)
             .ToList()
            .ForEach(stream =>
            {

                objMuxedStreamInfos.Add(new objMuxedStreamInfo()
                {
                    Url = stream.Url,
                    Size = stream.Size.MegaBytes.ToString(),
                    AudioCodec = stream.AudioCodec,
                    VideoCodec = stream.VideoCodec,
                    Framerate = stream.VideoQuality.Framerate.ToString(),
                    VideoQuality = stream.VideoQuality.Label,
                    VideoResolution = $"w:{stream.VideoResolution.Width} h:{stream.VideoResolution.Height}"
                });
            });
            StreamInfoList.objMuxedStreamInfos = objMuxedStreamInfos;

            // Audio ///////////////////////////////////////////////////////////////////////
            List<objAudioStreamInfo> objAudioStreamInfos = new List<objAudioStreamInfo>();
            streamManifest.GetAudioStreams().OrderBy(p => p.Bitrate.BitsPerSecond)
             .ToList().ForEach(stream =>
             {
                 objAudioStreamInfos.Add(new objAudioStreamInfo()
                 {
                     Url = stream.Url,
                     AudioCodec = stream.AudioCodec,
                     Size = stream.Size.MegaBytes.ToString(),
                     Bitrate = stream.Bitrate.BitsPerSecond.ToString(),

                 });
             });
            StreamInfoList.objAudioStreamInfos = objAudioStreamInfos;
            // Video ///////////////////////////////////////////////////////////////////////
            List<objVideoStreamInfo> objVideoStreamInfos = new List<objVideoStreamInfo>();
            streamManifest.GetVideoStreams().OrderBy(p => p.VideoResolution.Area)
             .ToList().ForEach(stream =>
             {
                 objVideoStreamInfos.Add(new objVideoStreamInfo()
                 {
                     Url = stream.Url,
                     Size = stream.Size.MegaBytes.ToString(),
                     Framerate = stream.VideoQuality.Framerate.ToString(),
                     VideoCodec = stream.VideoCodec,
                     VideoQuality = stream.VideoQuality.Label,
                     VideoResolution = $"w:{stream.VideoResolution.Width} h:{stream.VideoResolution.Height}"
                 });
             });
            objVideoStreamInfos.Reverse();
            StreamInfoList.objVideoStreamInfos = objVideoStreamInfos;
            StreamInfoList.videoId = videoId;

            G_.CacheData.YouTubeDownloaderLinks.Add(StreamInfoList);

            return StreamInfoList;
        }
    }
}
