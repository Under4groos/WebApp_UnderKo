using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp_UnderKo.Models.JsonObjects;
using WebApp_UnderKo.Models.Request;

namespace WebApp_UnderKo.Models.RazorPage
{
    public class base_CheckPage : PageModel
    {
        public void Init()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.HttpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                string ip_str_ = this.HttpContext.Request.Headers["X-Real-IP"];
                stringBuilder.Append($"[{ip_str_}]");

                WebReq.AsyncRequest($"http://ip-api.com/json/{ip_str_}?fields=regionName,city,as", (string url, string jsonresult) =>
                {
                    objIPCheckerResult myDeserializedClass = JsonConvert.DeserializeObject<objIPCheckerResult>(jsonresult);
                    stringBuilder.Append($"[{myDeserializedClass.city}] - ");
                });


            }
            stringBuilder.Append(this.HttpContext.Request.Method + " - ");
            stringBuilder.Append(this.HttpContext.Request.Path + this.HttpContext.Request.QueryString);



            G_.logger.NewLine($"{stringBuilder}");
        }
    }
}
