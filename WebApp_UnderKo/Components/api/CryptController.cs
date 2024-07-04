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
        [HttpGet("encrypt")]
        public IActionResult _encrypt(string plaintext, KeySize keySize, string password)
        {
            this.Init();
            //// http://localhost:7076/api/crypt?mode=encrypt&data=12222222&password=1sdfdsf
            try
            {
                return Content(Rijndael.Encrypt(plaintext, keySize, password));
            }
            catch (Exception e)
            {

                G_.logger.NewLine(e.Message);
                return Content($"{e}");
            }
        }
        [HttpGet("decrypt")]
        public IActionResult _decrypt(string plaintext, KeySize keySize, string password)
        {
            this.Init();
            //// http://localhost:7076/api/crypt?mode=encrypt&data=12222222&password=1sdfdsf
            try
            {
                return Content(Rijndael.Decrypt(plaintext, keySize, password));
            }
            catch (Exception e)
            {

                G_.logger.NewLine(e.Message);
                return Content($"{e}");
            }
        }


    }
}
