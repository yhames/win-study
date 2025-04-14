using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
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
        public Image? Profile { get; set; } // 프로필 사진

        public async Task LoadUserDetail(int userId)
        {
            DUser result = await _userService.GetDUsersAsync(userId);
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
    }
}
