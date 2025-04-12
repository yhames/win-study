using System.Net.Http;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using Newtonsoft.Json;

namespace DevExpressApp.Service
{
    public interface IPostService
    {
        Task<PaginationResponse<MPost>> GetPostsAsync(int page, int perPage);
        Task<DPost> GetDPostsAsync(string postId);
    }

    public class PostService : IPostService
    {
        private const string GetPostsPath = "/posts";
        private const string GetPostPath = "/posts/detail";

        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginationResponse<MPost>> GetPostsAsync(int page, int perPage)
        {
            string url = $"{GetPostsPath}?page={page}&perPage={perPage}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginationResponse<MPost>>(content);
            if (result == null)
            {
                throw new Exception("GetPostAsync: Failed to deserialize response");
            }

            return result;
        }

        public async Task<DPost> GetDPostsAsync(string postId)
        {
            string url = $"{GetPostPath}/{postId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DPost>(content);
            if (result == null)
            {
                throw new Exception("GetDPostsAsync: Failed to deserialize response");
            }

            return result;
        }
    }
}
