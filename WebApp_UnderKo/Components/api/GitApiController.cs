using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WebApp_UnderKo.Models.RazorPage;
using WebApp_UnderKo.Models.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_UnderKo.Components.api
{

    [ApiController]
    public class GitApiController : ControllerBase
    {
        public GitApiController()
        {
            this.Init();
        }

        // https://api.github.com/repos/Under4groos/SmdCompile.View/releases
        [HttpGet("api/releases")]
        public string GetProject(string project)
        {
            return WebReq.Request($"https://api.github.com/repos/Under4groos/{project}/releases").Result;
        }

        [HttpGet("api/releases/countdownload")]
        public async Task<IActionResult> GetProjectCountDownload(string project)
        {
            return Ok(__GetProjectCountDownload($"https://api.github.com/repos/Under4groos/{project}/releases"));
        }
        public static async Task<int> __GetProjectCountDownload(string project)
        {
            string json_txt = await WebReq.Request(Regex.Replace(project, "(\n|\t| )", ""));
            if (string.IsNullOrEmpty(json_txt))
            {
                return 0;
            }
            int download_count = 0;
            dynamic json_obj = JsonConvert.DeserializeObject(json_txt);
            if (json_obj != null)
                if (json_obj[0] != null)
                {
                    foreach (var asset in json_obj)
                    {

                        foreach (var item in asset["assets"])
                        {
                            download_count += (int)item["download_count"];

                        }
                    }

                }


            return download_count;
        }
        public static async Task<object?> __GetProject(string project)
        {
            string json_txt = await WebReq.Request(Regex.Replace(project, "(\n|\t| )", ""));
            if (string.IsNullOrEmpty(json_txt))
            {
                return 0;
            }

            return JsonConvert.DeserializeObject(json_txt);

        }
    }
}
