using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class UserResponseDto:UserBaseDto
    {
        public string Token { get; set; }
    }
}