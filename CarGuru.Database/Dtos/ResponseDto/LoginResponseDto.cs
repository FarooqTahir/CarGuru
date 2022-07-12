using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class LoginResponseDto
    {
        public int RoleId { get; set; }
        public string ProfileUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public string OpenTokToken { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }
    }
}