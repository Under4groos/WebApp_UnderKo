using WebApp_UnderKo.Models.Request;

namespace WebApp_UnderKo.Models.GitHub
{
    public class Git
    {
        public Action Event_AppendItemsRepositories { get; set; }

        public GitHubUserProfileData ProfileData { get; set; } = new GitHubUserProfileData();
        public List<Models.GitHub.Item> GitHubReposList = new List<Models.GitHub.Item>();
        public void Init_Profile(string username)
        {
            WebReq.AsyncRequest($"https://api.github.com/users/{username}", (string url, string result) =>
            {
                try
                {
                    ProfileData = new Models.Serializator.Json.JsonSerializator<GitHubUserProfileData>().DeserializeObject(result);


                }
                catch (Exception e)
                {
                    G_.logger.NewLine(e.Message);

                }

            });
        }
        public void GetRepositories(string username)
        {

            int pages_ = 30;
            int d = 165 / pages_;
            GitHubReposList.Clear();
            for (int i = 0; i < d; i++)
            {
                WebReq.AsyncRequest($"https://api.github.com/search/repositories?q=user:{username}&per_page={pages_}&sort=updated&page={i}", (string url, string result) =>
                {
                    Models.GitHub.GitHubRepos data = new Models.Serializator.Json.JsonSerializator<Models.GitHub.GitHubRepos>().DeserializeObject(result);
                    if (data.items.Count > 0)
                    {
                        foreach (Item item in data.items)
                        {

                            GitHubReposList.Add(item);

                        }
                        Event_AppendItemsRepositories?.Invoke();
                    }

                });
            }

        }



    }
}
