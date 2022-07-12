using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class CustomerResponseDto:CustomerBaseDto
    {
        public UserResponseDto User { get; set; }       
    }
}