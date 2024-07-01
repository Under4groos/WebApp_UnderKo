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
            return this.Content(G_.ApiList_Serializator.SerializeObject(G_.CacheData.apiList, type));


        }
        [HttpGet("{id}")]
        public IActionResult Get(int id, enumType type = enumType.json)
        {
            if (G_.CacheData.apiList.webApis.Count > 0 && id > 0 && id < G_.CacheData.apiList.webApis.Count)
                return this.Content(G_.WebApi_Serializator.SerializeObject(G_.CacheData.apiList.webApis[id], type));
            return this.Content($"Range Exception: Index was out of range.");
        }
    }
}
