namespace DevExpressApp.Model
{
    public class DUser
    {
        public string Id { get; set; } // PK
        public string UserId { get; set; } // (m_user)
        public string Email { get; set; } // 이메일
        public string Address { get; set; } // 주소
        public string PhoneNumber { get; set; } // 전화번호
        public DateTime DateOfBirth { get; set; } // 생년월일
        public string Gender { get; set; } // 성별
        public string Occupation { get; set; } // 직업
        public string Nationality { get; set; } // 국적
        public string ProfilePictureUrl { get; set; } // 프로필 사진 URL
    }
}
