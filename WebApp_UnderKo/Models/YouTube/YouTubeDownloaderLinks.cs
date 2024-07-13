using YoutubeExplode.Videos;
namespace WebApp_UnderKo.Models.YouTube
{
    public struct YouTubeDownloaderLinks
    {
        public YouTubeDownloaderLinks()
        {
        }

        public VideoId videoId;
        public DateTime PostDateTime;
        public List<objMuxedStreamInfo> objMuxedStreamInfos = new List<objMuxedStreamInfo>();
        public List<objAudioStreamInfo> objAudioStreamInfos = new List<objAudioStreamInfo>();
        public List<objVideoStreamInfo> objVideoStreamInfos = new List<objVideoStreamInfo>();

        public bool IsValid()
        {
            return objMuxedStreamInfos.Count > 0 || objAudioStreamInfos.Count > 0 || objVideoStreamInfos.Count > 0;
        }

        public void UpdateTime()
        {
            PostDateTime = DateTime.Now;
        }
        public void Clear()
        {
            objMuxedStreamInfos.Clear();
            objAudioStreamInfos.Clear();
            objVideoStreamInfos.Clear();
        }
    }
}
