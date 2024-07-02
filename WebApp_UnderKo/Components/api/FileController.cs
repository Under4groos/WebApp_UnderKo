using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.IO.Storage;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Components.api
{
    [Route("file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name)
        {
            this.Init();
            string ___file;
            string contentType = "text/html";
            foreach (string OpenDir_ in G_.CacheData.OpenDirectories)
            {
                ___file = Path.Combine(G_.CacheData.PATH_WWWROOT, OpenDir_, name);
                if (System.IO.File.Exists(___file))
                {
                    string ext = Path.GetExtension(___file);




                    if (!G_.FileExtension.TryGetContentType(ext, out contentType))
                    {
                        G_.logger.NewLine($"Unable to find Content Type for file name {ext}.");

                    }
                    G_.logger.NewLine($"[File][{contentType}]: {___file}");
                    return File(System.IO.File.ReadAllBytes(___file), contentType);
                }

            }

            return this.Content($"File not found: \"{name}\"");
        }





        public static List<StorageFile> Storage_GetFiles()
        {
            List<StorageFile> files = new List<StorageFile>();
            foreach (var dir__ in G_.CacheData.OpenDirectories)
            {
                files.AddRange((
                    from file__ in Directory.GetFiles(Path.Combine(G_.CacheData.PATH_WWWROOT, dir__), "*.*", SearchOption.AllDirectories)

                    select new StorageFile(file__)
                    ).ToArray());

            }
            return files;
        }

    }
}
