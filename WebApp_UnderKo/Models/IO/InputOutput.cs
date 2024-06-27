using System.Text;

namespace WebApp_UnderKo.Models.IO
{
    public static class InputOutput
    {
        public static async Task<bool> Write(string path, string data)
        {
            try
            {
                using (FileStream writeter = File.OpenWrite(path))
                {
                    byte[] encodedText = Encoding.UTF8.GetBytes(data);
                    await writeter.WriteAsync(encodedText, 0, encodedText.Length);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }
        public static async Task<bool> Read(string path, Action<string> result)
        {
            if (File.Exists(path))
                using (StreamReader reader = File.OpenText(path))
                {
                    var fileText = await reader.ReadToEndAsync();
                    result?.Invoke(fileText);
                    return true;
                }
            return false;
        }
    }
}
