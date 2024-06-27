namespace WebApp_UnderKo.Models.YouTube
{
    public class objMuxedStreamInfo()
    {
        public string Url { get; set; }
        public string Size { get; set; }
        public string AudioCodec { get; set; }
        public string VideoCodec { get; set; }
        public string VideoQuality { get; set; }
        public string VideoResolution { get; set; }
        public string Framerate { get; set; }
    }
    public class objAudioStreamInfo()
    {

        public string Url { get; set; }
        public string Size { get; set; }
        public string Bitrate { get; set; }
        public string AudioCodec { get; set; }

    }
    public class objVideoStreamInfo()
    {

        public string Url { get; set; }
        public string Size { get; set; }

        public string VideoCodec { get; set; }
        public string VideoQuality { get; set; }
        public string VideoResolution { get; set; }

        public string Framerate { get; set; }
    }
}
