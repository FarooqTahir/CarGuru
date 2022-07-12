using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;

namespace CarGuru.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseDto<List<EmployeeResponseDto>>> CreateAsync(EmployeeRequestDto model);
        Task<ResponseDto<List<EmployeeResponseDto>>> UpdateAsync(EmployeeRequestDto model);
        Task<ResponseDto<EmployeeResponseDto>> GetByIdAsync(long id);
        Task<ResponseDto<List<EmployeeResponseDto>>> GetAllAsync(string name);
        Task<ResponseDto<List<EmployeeResponseDto>>> DeleteEmployee(long Id);
        Task<List<EmployeeResponseDto>> GetAllAgents();
        Task<ResponseDto<UpdateEmployeeApiDto>> UpdateEmployeeApi(UpdateEmployeeApiDto model);
        Task<ResponseDto<UpdateEmployeeApiDto>> GetEmployeeApi(long UserId);
        ResponseDto<TechnicianLocationApiDto> UpdateTechnicianLocation(TechnicianLocationApiDto model);
    }
}