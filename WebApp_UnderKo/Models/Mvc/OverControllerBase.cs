using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp_UnderKo.Models.Mvc
{
    public class OverControllerBase : ControllerBase
    {
        public ActionResult ContentJson(object obj)
        {
            return this.Content(JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}
