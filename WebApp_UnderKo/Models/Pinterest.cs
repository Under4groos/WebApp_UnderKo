using Parser.PinterestMediaLib.Structures;

namespace WebApp_UnderKo.Models
{
    public class Pinterest
    {
        public string cookie = string.Empty;

        public Dictionary<string, List<Video>> DictionaryLinksVideo = new Dictionary<string, List<Video>>();
    }
}
