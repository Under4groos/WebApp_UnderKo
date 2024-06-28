using System.Net;
using System.Text;
using WebApp_UnderKo.Models.IO;

namespace WebApp_UnderKo.Models.Request
{
    public static class WebReq
    {
        public static Dictionary<string, string> GetQuery(this Uri uri)
        {
            string[] ayy = null;
            Dictionary<string, string> _r_Query = new Dictionary<string, string>();
            foreach (string item in uri.Query.Split('&'))
            {
                ayy = item.Split('=');
                if (ayy.Length == 2)
                {
                    if (ayy[0].StartsWith("?"))
                        ayy[0] = ayy[0].Substring(1);
                    _r_Query.Add(ayy[0], ayy[1]);

                }
            }
            return _r_Query;
        }
        private static async void GetResponseAsync(this WebRequest request, Action<string, string> result)
        {
            using (var responce = await request.GetResponseAsync())
            {
                using (var content = new MemoryStream())
                using (var responseStream = responce.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                    byte[] bytes__ = content.ToArray();

                    result?.Invoke(request.RequestUri.AbsolutePath, Encoding.UTF8.GetString(bytes__, 0, bytes__.Length));
                }
            }
        }

        public static async void AsyncRequest(string url, Action<string, string> result, HttpMethods methods = HttpMethods.GET)
        {
            if (string.IsNullOrEmpty(url))
                return;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = methods.ToString();
            request.Timeout = 20000;
            request.Proxy = null;
            request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            G_.logger.NewLine($"[{request.Method}]: {url}");

            if (url.StartsWith("https://github.com/") || url.StartsWith("https://api.github.com/"))
            {
                await InputOutput.PATH_BASE_LocalRead(@"Data\__githubapi.key.txt",
                (string rresult) =>
                {
                    request.Headers.Add("Authorization", "Bearer " + rresult);

                    request.GetResponseAsync(result);
                }, true);
                return;
            }
            request.GetResponseAsync(result);

        }

    }
}
