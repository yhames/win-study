using System.Net.Http;
using System.Web;
using DevExpress.Data.Utils;
using DevExpress.Xpo.DB.Helpers;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using Newtonsoft.Json;

namespace DevExpressApp.Service
{
    public interface IPostService
    {
        Task<PaginationResponse<MPost>> GetPostsAsync(int page, int perPage);
        Task<DPost> GetDPostsAsync(int postId);
    }

    public class PostService : IPostService
    {
        private const string GetPostsPath = "/posts";
        private const string GetPostPath = "/api/posts/detail";

        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginationResponse<MPost>> GetPostsAsync(int page, int perPage)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["page"] = page.ToString();
            query["perPage"] = perPage.ToString();

            UriBuilder uriBuilder = new UriBuilder(GetPostsPath);
            uriBuilder.Query = query.ToString();
            string url = uriBuilder.ToString();

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

        public async Task<DPost> GetDPostsAsync(int postId)
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
