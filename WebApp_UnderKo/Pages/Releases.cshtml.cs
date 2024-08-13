using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp_UnderKo.Components.api;
using WebApp_UnderKo.Models;

namespace WebApp_UnderKo.Pages
{
    public class ReleasesModel : PageModel
    {
        public List<(string, string, (string, string))> Names = new List<(string, string, (string, string))>();
        public string JsonDataReq = string.Empty;
        public async Task<IActionResult> OnGet(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                return this.Redirect("/Error");

            var projects_ = (from pro in G_.CacheData.xamlProjectsData.Projects where name == pro.Name select pro);
            int count_ = projects_.Count();
            if (count_ == 0)
                return this.Redirect("/project");

            var ptrj_ = projects_.First();
            if (string.IsNullOrEmpty(ptrj_.GitHubLinkReleases))
                return this.Redirect("/Error");

            dynamic? obj = await GitApiController.__GetProject(ptrj_.GitHubLinkReleases);

            if (obj != null)
            {
                foreach (var item in obj)
                {
                    if (item == null)
                        continue;
                    string tag_name = (string?)item["tag_name"] ?? "NULL";
                    string body = (string?)item["body"] ?? "NULL";
                    string html_url = (string?)item["html_url"] ?? "#";
                    string browser_download_url = string.Empty;
                    if (item["assets"] != null)
                    {
                        var i_ = item["assets"][0];
                        if (i_ != null)
                        {
                            browser_download_url = i_["browser_download_url"];
                        }
                    }
                    Names.Add((tag_name, body, (html_url, browser_download_url)));


                }
            }

            JsonDataReq = JsonConvert.SerializeObject(obj);
            return this.Page();
        }
    }
}
