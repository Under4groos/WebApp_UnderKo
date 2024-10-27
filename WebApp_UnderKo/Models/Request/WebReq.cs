using System.Net;
using System.Text;

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
        private static async Task GetResponseAsync(this WebRequest request, Action<string, string> result)
        {
            try
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
            catch (Exception e)
            {

                G_.logger.NewLine($"{request.RequestUri.AbsolutePath}\n{e.Message}", Log.ELoggerExtensions.Error);
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
                if (G_.git.API_KEY.Length < 30)
                    return;
                request.Headers.Add("Authorization", "Bearer " + G_.git.API_KEY);

                await request.GetResponseAsync(result);
                return;
            }
            await request.GetResponseAsync(result);

        }
        public static async Task<string> RequestNoneLimite(string url, HttpMethods methods = HttpMethods.GET)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = methods.ToString();
                request.Timeout = 20000;
                request.Proxy = null;
                request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                G_.logger.NewLine($"[{request.Method}]: {url}");

                using (var responce = await request.GetResponseAsync())
                {
                    using (var content = new MemoryStream())
                    using (var responseStream = responce.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);
                        byte[] bytes__ = content.ToArray();

                        return Encoding.UTF8.GetString(bytes__, 0, bytes__.Length);
                    }
                }
            }
            catch (Exception e)
            {

                G_.logger.NewLine(e.Message, Log.ELoggerExtensions.Error);
            }
            return string.Empty;

        }



        public static async Task<string> Request(string url, HttpMethods methods = HttpMethods.GET)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = methods.ToString();
                request.Timeout = 20000;
                request.Proxy = null;
                request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                G_.logger.NewLine($"[{request.Method}]: {url}");

                if (url.StartsWith("https://github.com/") || url.StartsWith("https://api.github.com/"))
                {
                    request.Headers.Add("Authorization", "Bearer " + G_.git.API_KEY);

                    using (var responce = await request.GetResponseAsync())
                    {
                        using (var content = new MemoryStream())
                        using (var responseStream = responce.GetResponseStream())
                        {
                            await responseStream.CopyToAsync(content);
                            byte[] bytes__ = content.ToArray();

                            return Encoding.UTF8.GetString(bytes__, 0, bytes__.Length);
                        }
                    }

                }
            }
            catch (Exception e)
            {

                G_.logger.NewLine(e.Message, Log.ELoggerExtensions.Error);
            }
            return string.Empty;

        }
    }
}
