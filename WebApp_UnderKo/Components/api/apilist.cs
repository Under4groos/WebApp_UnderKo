using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.Serializator;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/apilist")]
    [ApiController]
    public class apilist : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(enumType type = enumType.json)
        {
            switch (type)
            {
                case enumType.Xaml:
                    return this.Content(G_.xaml_ApiList.SerializeObject(G_.CacheData.apiList));
                case enumType.json:
                    return this.Content(G_.json_ApiList.SerializeObject(G_.CacheData.apiList));
                default:
                    return this.Content("Error!");
            }

        }
    }
}
