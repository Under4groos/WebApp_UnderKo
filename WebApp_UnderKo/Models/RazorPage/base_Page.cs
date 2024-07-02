using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp_UnderKo.Models.JsonObjects;
using WebApp_UnderKo.Models.Request;

namespace WebApp_UnderKo.Models.RazorPage
{
    public static class base_Page
    {
        public static void Init(this PageModel pageModel)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (pageModel.HttpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                string ip_str_ = pageModel.HttpContext.Request.Headers["X-Real-IP"];
                stringBuilder.Append($"[{ip_str_}]");

                WebReq.AsyncRequest($"http://ip-api.com/json/{ip_str_}?fields=regionName,city,as", (string url, string jsonresult) =>
                {
                    objIPCheckerResult myDeserializedClass = JsonConvert.DeserializeObject<objIPCheckerResult>(jsonresult);
                    stringBuilder.Append($"[{myDeserializedClass.city}] - ");
                });


            }

            stringBuilder.Append(pageModel.HttpContext.Request.Method + " - ");
            stringBuilder.Append(pageModel.HttpContext.Request.Path + pageModel.HttpContext.Request.QueryString);
            G_.logger.NewLine($"{stringBuilder}");
        }
    }
    public static class base_ControllerBase
    {

        public static void Init(this ControllerBase controllerBase)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (controllerBase.HttpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                string ip_str_ = controllerBase.HttpContext.Request.Headers["X-Real-IP"];
                stringBuilder.Append($"[{ip_str_}]");

                WebReq.AsyncRequest($"http://ip-api.com/json/{ip_str_}?fields=regionName,city,as", (string url, string jsonresult) =>
                {
                    objIPCheckerResult myDeserializedClass = JsonConvert.DeserializeObject<objIPCheckerResult>(jsonresult);
                    stringBuilder.Append($"[{myDeserializedClass.city}] - ");
                });


            }

            stringBuilder.Append(controllerBase.HttpContext.Request.Method + " - ");
            stringBuilder.Append(controllerBase.HttpContext.Request.Path + controllerBase.HttpContext.Request.QueryString);
            G_.logger.NewLine($"{stringBuilder}");
        }
    }
}
