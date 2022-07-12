using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IFleetService
    {
        Task<ResponseDto<List<FleetResponseDto>>> CreateAsync(FleetRequestDto model);
        Task<ResponseDto<List<FleetResponseDto>>> UpdateAsync(FleetRequestDto model);
        Task<ResponseDto<List<FleetResponseDto>>> DeleteAsync(long Id);
        Task<ResponseDto<List<FleetResponseDto>>> GetAllAsync();
        Task<ResponseDto<FleetResponseDto>> GetByIdAsync(long id);
    }
}
