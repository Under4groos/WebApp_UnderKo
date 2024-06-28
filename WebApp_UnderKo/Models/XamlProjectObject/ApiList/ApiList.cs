namespace WebApp_UnderKo.Models.XamlProjectObject.ApiList
{
    public class ApiList
    {
        public List<WebApi> webApis { get; set; } = new List<WebApi>();
        public void __init_null()
        {
            webApis.Clear();
            for (int i = 0; i < 3; i++)
            {
                webApis.Add(new WebApi()
                {
                    URL = $"https://asd.asd/{i}",
                    reqQueries = new List<ReqQuery>()
                    {
                        new ReqQuery()
                        {
                             Name = "asd",
                             Description = $" asdasd {i}",
                             Parametr = $"asdasdsa {i}"
                        },
                        new ReqQuery()
                        {
                             Name = "asd",
                             Description = $" asdasd {i}",
                             Parametr = $"asdasdsa {i}"
                        }
                    }
                });
            }

        }
    }
}
