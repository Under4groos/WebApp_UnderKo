using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace WebApp_UnderKo.Models.RazorPage
{
    public static class base_IPCheker
    {
        public static string LogIp(this HttpContext httpContext)
        {
            string ip_str_ = $"0.0.0.0:0000";
            if (httpContext == null)
            {
                G_.logger.NewLine($"HttpContext: null");
                return $"0.0.0.0:0000";
            }
            StringBuilder stringBuilder = new StringBuilder();
            if (httpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                ip_str_ = httpContext.Request.Headers["X-Real-IP"];
                stringBuilder.Append($"[{ip_str_}] ");
            }
            stringBuilder.Append(httpContext.Request.Method + " - ");
            stringBuilder.Append(httpContext.Request.Path + httpContext.Request.QueryString);
            G_.logger.NewLine($"{stringBuilder}");
            return ip_str_;
        }
    }
    public static class base_Page
    {
        public static void Init(this PageModel pageModel)
        {
            pageModel.HttpContext.LogIp();
        }
    }
    public static class base_ControllerBase
    {
        public static void Init(this ControllerBase controllerBase)
        {
            controllerBase.HttpContext.LogIp();
        }
    }
}
