using System.Net.Http;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using Newtonsoft.Json;

namespace DevExpressApp.Service
{
    public interface IUserService
    {
        Task<PaginationResponse<MUser>> GetMUsersAsync(int page, int perPage);
        Task<PaginationResponse<DUser>> GetDUsersAsync(int page, int perPage);
    }

    public class UserService : IUserService
    {
        private const string GetMUserPath = "/users";
        private const string GetDUserPath = "/users/detail";
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginationResponse<MUser>> GetMUsersAsync(int page, int perPage)
        {
            string url = $"{GetMUserPath}?page={page}&perPage={perPage}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginationResponse<MUser>>(content);
            if (result == null)
            {
                throw new Exception("GetMUsersAsync: Failed to deserialize response");
            }
            return result;
        }

        public async Task<PaginationResponse<DUser>> GetDUsersAsync(int page, int perPage)
        {
            string url = $"{GetDUserPath}?page={page}&perPage={perPage}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginationResponse<DUser>>(content);
            if (result == null)
            {
                throw new Exception("GetMUsersAsync: Failed to deserialize response");
            }
            return result;
        }
    }
}
