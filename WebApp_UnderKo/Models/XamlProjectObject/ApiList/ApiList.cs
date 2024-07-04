using Rijndael256;

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
                    Name = Rijndael.Encrypt(G_.Random.Next(0, 999999).ToString(), KeySize.Aes256),
                    URL = $"https://asd.asd/{i}",
                    reqQueries = new List<ReqQuery>()
                    {
                         new ReqQuery()
                         {

                         }
                    }
                });
            }

        }
    }
}
