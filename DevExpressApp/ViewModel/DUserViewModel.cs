using System.ComponentModel;
using DevExpress.Mvvm.DataAnnotations;
using DevExpressApp.Dto.Response;
using DevExpressApp.Model;
using DevExpressApp.Service;

namespace DevExpressApp.ViewModel
{
    [POCOViewModel()]

    public class DUserViewModel(IUserService userService)
    {
        private readonly IUserService _userService = userService;

        public string UserId { get; set; } // (m_user)
        public string Email { get; set; } // 이메일
        public string Address { get; set; } // 주소
        public string PhoneNumber { get; set; } // 전화번호
        public DateTime DateOfBirth { get; set; } // 생년월일
        public string Gender { get; set; } // 성별
        public string Occupation { get; set; } // 직업
        public string Nationality { get; set; } // 국적
        public Image Profile { get; set; } // 프로필 사진 URL

        public async Task LoadData()
        {
            try
            {
                DUser result = await _userService.GetDUsersAsync(1);
                UserId = result.UserId;
                Email = result.Email;
                Address = result.Address;
                PhoneNumber = result.PhoneNumber;
                DateOfBirth = result.DateOfBirth;
                Gender = result.Gender;
                Occupation = result.Occupation;
                Nationality = result.Nationality;
                Profile = await _userService.GetProfileImageAsync(result.ProfilePictureUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user details: {ex.Message}");
            }
        }
    }
}
