using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class LoginRequestDto:LoginBaseDto
    {
        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
        public string TimeZone { get; set; }
    }
}