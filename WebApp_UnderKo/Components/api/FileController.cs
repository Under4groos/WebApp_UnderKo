using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name)
        {
            string directpry_;
            foreach (string OpenDir_ in G_.CacheData.OpenDirectories)
            {
                directpry_ = Path.Combine(G_.CacheData.PATH_WWWROOT, OpenDir_);


            }
            return this.Content("");
        }
    }
}
