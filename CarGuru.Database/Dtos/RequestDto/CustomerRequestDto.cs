using CarGuru.Database.Dtos.BaseDto;
using Microsoft.AspNetCore.Http;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class CustomerRequestDto:CustomerBaseDto
    {
        public  UserRequestDto User { get; set; }
        
        public string ProfileUrl { get; set; }
    }
}