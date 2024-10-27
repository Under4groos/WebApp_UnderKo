using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {

        // GET: api/<IPController>
        [HttpGet("check")]
        public string Check()
        {
            G_.CacheData.IPController_ListIP.Add(this.HttpContext.LogIp());
            return G_.CacheData.IPController_ListIP.First();
        }
        [HttpGet("list")]
        public async Task<string[]> List()
        {
            // https://ipwho.is/8.8.4.4?output=json&fields=city
            List<string> list = new List<string>();
            foreach (string item in G_.CacheData.IPController_ListIP)
            {
                try
                {
                    var arr_ = await WebReq.RequestNoneLimite($"https://ipwho.is/{item}?output=json&fields=city");
                    list.Add($"{item} {arr_}");
                }
                catch (Exception)
                {

                    list.Add(item);
                }
            }
            return list.ToArray();
        }
        [HttpGet("clear")]
        public void Clear()
        {

            G_.CacheData.IPController_ListIP.Clear();
            
        }

    }
}
