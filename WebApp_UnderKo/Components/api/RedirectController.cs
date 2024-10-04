using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private HttpClient _client;
        // GET: api/<RedirectController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            _client = new HttpClient();



            var s = await _client.GetStreamAsync("https://rr1---sn-n8v7kn7y.googlevideo.com/videoplayback?expire=1728095923&ei=U1IAZ9_LGqiPv_IPm6eXgAw&ip=62.109.19.41&id=o-AIncocHezhdaSTLaSsbHEWJdoJGTNQI436veZXCErObO&itag=137&source=youtube&requiressl=yes&xpc=EgVo2aDSNQ%3D%3D&mh=FJ&mm=31%2C29&mn=sn-n8v7kn7y%2Csn-n8v7znly&ms=au%2Crdu&mv=m&mvi=1&pl=22&initcwndbps=597500&vprv=1&svpuc=1&mime=video%2Fmp4&rqh=1&gir=yes&clen=16650774&dur=29.866&lmt=1710753202929715&mt=1728073971&fvip=10&keepalive=yes&fexp=51300761&c=IOS&txp=630A224&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cxpc%2Cvprv%2Csvpuc%2Cmime%2Crqh%2Cgir%2Cclen%2Cdur%2Clmt&sig=AJfQdSswRAIgHQkZrCvOCQ-JuElG1-36idNVSf7LENZZAPl3K0XQw-wCIE_mkVhDDHt1pVuOvLVnW06aQljNfVo5pfHjjq4zl5q2&lsparams=mh%2Cmm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl%2Cinitcwndbps&lsig=ACJ0pHgwRAIgWlHvWtcADny3zzdhz0hDM9zgxDqesR3sDhiQpwiknzsCIDa4C_N4y6cSbORmWA0hNoI9CUwUdtRHgBQuHCuo3C-2");



            this.File(s, "video/mp4");

            return Ok(s);

        }



    }
}
