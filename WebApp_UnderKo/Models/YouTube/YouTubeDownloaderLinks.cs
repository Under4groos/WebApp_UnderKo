
using YoutubeExplode.Videos;
namespace WebApp_UnderKo.Models.YouTube
{
    public class YouTubeDownloaderLinks
    {

        public VideoId videoId;
        public List<objMuxedStreamInfo> objMuxedStreamInfos = new List<objMuxedStreamInfo>();
        public List<objAudioStreamInfo> objAudioStreamInfos = new List<objAudioStreamInfo>();
        public List<objVideoStreamInfo> objVideoStreamInfos = new List<objVideoStreamInfo>();
    }
}
