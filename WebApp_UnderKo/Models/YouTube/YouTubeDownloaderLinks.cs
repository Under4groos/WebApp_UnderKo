
using VideoLibrary;

namespace WebApp_UnderKo.Models.YouTube
{
    public struct YouTubeDownloaderLinks
    {
        public YouTubeDownloaderLinks()
        {
        }


        public List<YouTubeVideo> LinksYouTubeVideo = new List<YouTubeVideo>();
        public List<YouTubeVideo> LinksYouTubeVideoAudio = new List<YouTubeVideo>();
        public List<YouTubeVideo> LinksYouTubeVideoNone = new List<YouTubeVideo>();
        public bool IsValid()
        {
            return (LinksYouTubeVideo.Count > 0 || LinksYouTubeVideoAudio.Count > 0 || LinksYouTubeVideoNone.Count > 0);
        }


        public void Clear()
        {
            LinksYouTubeVideo.Clear();
            LinksYouTubeVideoAudio.Clear();
        }
    }
}
