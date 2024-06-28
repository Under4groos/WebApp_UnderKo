using ImageMagick;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/IconConverter")]
    [ApiController]
    public class IconConverterController : ControllerBase
    {
        public string ConvertImage(string fileimage, string newfilename, int Resize = 256)
        {

            try
            {
                using (MagickImage image = new MagickImage(fileimage))
                {
                    if (image.Width > Resize || image.Height > Resize)
                    {

                        image.Scale(Resize, Resize);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Resize Image\n ->New Size:{image.Width}x{image.Height}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    image.Write(newfilename);
                }
            }
            catch (Exception)
            {

                return fileimage;
            }

            return newfilename;
        }


        [HttpPost]
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {

            string filename__ = string.Empty;
            string directory = string.Empty;
            FileInfo fileInfo = new FileInfo(SingleFile.FileName);
            if (ModelState.IsValid)
            {
                if (SingleFile != null && SingleFile.Length > 0)
                {

                    string base_uploads_directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(base_uploads_directory))
                        Directory.CreateDirectory(base_uploads_directory);


                    filename__ = Model.Converter.FileEncryptName(SingleFile.FileName, fileInfo.Extension);

                    fileInfo = new FileInfo(Path.Combine(base_uploads_directory, filename__));
                    if (fileInfo.Exists)
                        fileInfo.Delete();
                    using (var stream = System.IO.File.Create(fileInfo.FullName))
                    {
                        try
                        {
                            await SingleFile.CopyToAsync(stream);
                        }
                        catch (Exception)
                        {


                        }

                    }

                    fileInfo = new FileInfo(Convert(fileInfo.FullName, fileInfo.FullName.Replace(fileInfo.Extension, ".ico")));
                    filename__ = fileInfo.Name;


                }
            }
            return this.Redirect($"/Converters/Icon{(System.IO.File.Exists(fileInfo.FullName) ? $"?guid={filename__}" : "")}");
        }
    }
}
