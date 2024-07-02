using Microsoft.AspNetCore.Mvc;
using Rijndael256;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.RazorPage;

namespace WebApp_UnderKo.Components.api
{
    [Route("api/crypt")]
    [ApiController]
    public class CryptController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get(string mode, string data, string password = null)
        {
            this.Init();
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
