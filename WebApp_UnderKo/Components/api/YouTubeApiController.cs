﻿using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models.Mvc.Result;
using WebApp_UnderKo.Models.YouTube;
using YoutubeExplode.Videos;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeApiController : ControllerBase
    {
        YouTubeDownloaderLinks StreamInfoList = new YouTubeDownloaderLinks();

        [HttpGet()]
        public ActionResult Get(string link = null)
        {
            if (string.IsNullOrEmpty(link))
                return new TextResult(new objError($"Processing error", "Link length: 0"));


            if (link.StartsWith("https://youtu.be/"))
            {
                link = "https://www.youtube.com/watch?v=" + link.Replace("https://youtu.be/", "").Replace("?", "&");
            }

            if (!link.StartsWith("https://www.youtube.com/watch"))
            {

                return new TextResult(new objError($"Processing error", "Link invalid"));

            }

            try
            {


                return new TextResult(__get(link).Result);

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


            var videoId = VideoId.Parse(link);
            foreach (var item in G_.CacheData.YouTubeDownloaderLinks)
            {
                if (item.videoId == videoId)
                    return item;
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
            StreamInfoList.objVideoStreamInfos = objVideoStreamInfos;
            StreamInfoList.videoId = videoId;

            G_.CacheData.YouTubeDownloaderLinks.Add(StreamInfoList);

            return StreamInfoList;
        }
    }
}
