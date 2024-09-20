using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{
    [Route("api/sysinfo")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        // GET: api/<SystemInfoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return G_.HTOP_DataConseole.Split('\n');
        }

        // GET api/<SystemInfoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


    }
}
