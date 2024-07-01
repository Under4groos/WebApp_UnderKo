using Microsoft.AspNetCore.Mvc;
using WebApp_UnderKo.Models;
using WebApp_UnderKo.Models.Serializator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{
    [Route("api/projectlist")]
    [ApiController]
    public class projectlist : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(enumType type = enumType.json)
        {
            return this.Content(G_.ProjectsData_Serializator.SerializeObject(G_.CacheData.xamlProjectsData, type));

        }

        // GET api/<projectlist>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, enumType type = enumType.json)
        {
            if (G_.CacheData.xamlProjectsData.Projects.Count > 0 && id > 0 && id < G_.CacheData.xamlProjectsData.Projects.Count)
                return this.Content(G_.XamlProject_Serializator.SerializeObject(G_.CacheData.xamlProjectsData.Projects[id], type));
            return this.Content($"Range Exception: Index was out of range.");
        }


    }
}
