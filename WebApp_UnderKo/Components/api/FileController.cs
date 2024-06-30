using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
            string ___file;
            string contentType = "text/html";
            foreach (string OpenDir_ in G_.CacheData.OpenDirectories)
            {
                ___file = Path.Combine(G_.CacheData.PATH_WWWROOT, OpenDir_, name);
                if (System.IO.File.Exists(___file))
                {
                    string ext = Path.GetExtension(___file);


                    var fileProvider = new FileExtensionContentTypeProvider();

                    if (!fileProvider.TryGetContentType(ext, out contentType))
                    {
                        G_.logger.NewLine($"Unable to find Content Type for file name {ext}.");

                    }
                    return File(System.IO.File.ReadAllBytes(___file), contentType);
                }

            }
            return this.Content($"File not found: \"{name}\"");
        }
    }
}
