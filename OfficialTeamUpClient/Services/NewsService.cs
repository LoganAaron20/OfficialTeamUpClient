using OfficialTeamUpClient.Models;

namespace OfficialTeamUpClient.Services
{
    public interface INewsService
    {
        Task<List<NewsModel>> GetLatestNewsAsync();
    }
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewsModel>> GetLatestNewsAsync()
        {
            try
            {
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return new List<NewsModel>();
        }
    }
}
