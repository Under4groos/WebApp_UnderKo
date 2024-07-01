using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using Rijndael256;
using System.Text.RegularExpressions;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/IconConverter")]
    [ApiController]
    public class IconConverterController : ControllerBase
    {
        public string ConvertImageToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return "data:image/jpg;base64," + Convert.ToBase64String(bytes);

        }
        public string FileEncryptName(FileInfo fio)
        {
            return FileEncryptName(fio.Name, fio.Extension);

        }
        public string FileEncryptName(string name, string Extension)
        {
            return Regex.Replace(Rijndael.Encrypt(name, KeySize.Aes256), "[\\W]+", "") + Extension;
        }
        public string ConvertImage(string fileimage, string newfilename, int W = 256, int H = 256)
        {

            try
            {
                using (MagickImage image = new MagickImage(fileimage))
                {
                    if (image.Width > W || image.Height > H)
                    {



                        image.VirtualPixelMethod = VirtualPixelMethod.Transparent;
                        image.Depth = 1;
                        image.FilterType = FilterType.Quadratic;
                        image.Transparent(MagickColor.FromRgb(0, 0, 0));
                        image.Format = MagickFormat.Ico;
                        image.Resize(W, H);



                        G_.logger.NewLine($"Resize Image: {image.Width}x{image.Height}", Models.Log.ELoggerExtensions.Debug);


                    }

                    image.Write(newfilename);

                }
                if (System.IO.File.Exists(fileimage))
                {
                    System.IO.File.Delete(fileimage);
                }
            }
            catch (Exception e)
            {

                G_.logger.NewLine(e.Message, Models.Log.ELoggerExtensions.Error);

                return e.Message;
            }

            return newfilename;
        }


        [HttpPost]
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {


            string filename__ = string.Empty;
            string directory = string.Empty;
            FileInfo fileInfo = new FileInfo(SingleFile.FileName);

            G_.logger.NewLine($"File upload Server: {SingleFile.FileName}");
            if (ModelState.IsValid)
            {
                if (SingleFile != null && SingleFile.Length > 0)
                {

                    string base_uploads_directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(base_uploads_directory))
                        Directory.CreateDirectory(base_uploads_directory);


                    filename__ = FileEncryptName(SingleFile.FileName, fileInfo.Extension);

                    fileInfo = new FileInfo(Path.Combine(base_uploads_directory, filename__));
                    if (fileInfo.Exists)
                        fileInfo.Delete();
                    using (var stream = System.IO.File.Create(fileInfo.FullName))
                    {
                        try
                        {
                            await SingleFile.CopyToAsync(stream);
                        }
                        catch (Exception e)
                        {

                            G_.logger.NewLine(e.Message, Models.Log.ELoggerExtensions.Error);
                        }

                    }

                    fileInfo = new FileInfo(ConvertImage(fileInfo.FullName, fileInfo.FullName.Replace(fileInfo.Extension, ".ico")));


                }
            }
            return this.Redirect($"/Converters/Icon{(System.IO.File.Exists(fileInfo.FullName) ? $"?guid={fileInfo.Name}" : "")}");
        }
    }
}
