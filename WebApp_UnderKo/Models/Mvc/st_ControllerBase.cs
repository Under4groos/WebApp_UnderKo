using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp_UnderKo.Models.Mvc
{
    public static class st_ControllerBase
    {
        public static ContentResult SerializeObject(this ControllerBase cb, object obj)
        {
            return cb.Content(JsonConvert.SerializeObject(obj, Formatting.Indented));

        }
    }
}
