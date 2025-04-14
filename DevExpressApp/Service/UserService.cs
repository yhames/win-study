using System.IO;
using System.Net.Http;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using Newtonsoft.Json;

namespace DevExpressApp.Service
{
    public interface IUserService
    {
        Task<PaginationResponse<MUser>> GetMUsersAsync(int page, int perPage);
        Task<DUser> GetDUsersAsync(int mUserId);
        Task<Image?> GetProfileImageAsync(string profilePictureUrl);
    }

    public class UserService : IUserService
    {
        private const string GetMUserPath = "/api/users";
        private const string GetDUserPath = "/api/users/detail";
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginationResponse<MUser>> GetMUsersAsync(int page, int perPage)
        {
            string url = $"{GetMUserPath}?page={page}&perPage={perPage}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            PaginationResponse<MUser>? result = JsonConvert.DeserializeObject<PaginationResponse<MUser>>(content);
            if (result == null)
            {
                throw new Exception("GetMUsersAsync: Failed to deserialize response");
            }
            return result;
        }

        public async Task<DUser> GetDUsersAsync(int mUserId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{GetDUserPath}/{mUserId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            DUser? result = JsonConvert.DeserializeObject<DUser>(content);
            if (result == null)
            {
                throw new Exception("GetMUsersAsync: Failed to deserialize response");
            }
            return result;
        }

        public async Task<Image?> GetProfileImageAsync(string profilePictureUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(profilePictureUrl);
                response.EnsureSuccessStatusCode();
                Stream imageStream = await response.Content.ReadAsStreamAsync();
                return Image.FromStream(imageStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading profile image: {ex.Message}");
                return null;
            }
        }
    }
}
