using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class EmployeeResponseDto:EmployeeBaseDto
    {
      public  UserResponseDto User { get; set; }
      public  RolesDto EmployeeType { get; set; }
    }
}