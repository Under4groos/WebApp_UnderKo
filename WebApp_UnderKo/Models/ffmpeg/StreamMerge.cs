using System.Diagnostics;

namespace WebApp_UnderKo.Models.ffmpeg
{
    public static class StreamMerge
    {
        public static bool Merge(string path_video, string path_audio, string path_output)
        {
            if (System.IO.File.Exists(path_video) && System.IO.File.Exists(path_audio))
            {
                if (System.IO.File.Exists(path_output))
                    System.IO.File.Delete(path_output);
                // ffmpeg -i video.mp4 -i audio.wav -c:v copy -c:a aac output.mp4



                try
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo("ffmpeg",
                    $"-i \"{path_video}\" -i \"{path_audio}\" -c:v copy -c:a aac \"{path_output}\""
                    );
                    Process proc = new Process();
                    proc.StartInfo = procStartInfo;

                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    proc.OutputDataReceived += (o, e) =>
                    {

                    };
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();


                }
                catch (Exception e)
                {

                    return false;
                }
            }
            return false;
        }
    }
}
