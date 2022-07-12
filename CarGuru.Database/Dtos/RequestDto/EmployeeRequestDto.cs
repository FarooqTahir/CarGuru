using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class EmployeeRequestDto:EmployeeBaseDto
    {
        public UserRequestDto User { get; set; }
    }
}