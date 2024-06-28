using Microsoft.AspNetCore.Mvc;
using Rijndael256;
using System.Text.RegularExpressions;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/crypt")]
    [ApiController]
    public class CryptController : ControllerBase
    {
        public string FileEncryptName(FileInfo fio)
        {
            return FileEncryptName(fio.Name, fio.Extension);

        }
        public string FileEncryptName(string name, string Extension)
        {
            return Regex.Replace(Rijndael.Encrypt(name, KeySize.Aes256), "[\\W]+", "") + Extension;
        }

        [HttpGet]
        public IActionResult Get(string mode, string data, string password = null)
        {
            //// http://localhost:7076/api/crypt?mode=encrypt&data=12222222&password=1sdfdsf
            try
            {
                switch (mode.ToLower().Trim())
                {
                    case "encrypt":
                        return Content(Rijndael.Encrypt(data, KeySize.Aes256, password));
                    case "decrypt":
                        return Content(Rijndael.Decrypt(data, KeySize.Aes256, password));
                    default:
                        return Content("Error");

                }
            }
            catch (Exception e)
            {
                G_.logger.NewLine(e.Message);
                return Content("Error");
            }



        }
    }
}
