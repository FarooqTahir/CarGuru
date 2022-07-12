using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;

namespace CarGuru.Services.Interfaces
{
    public interface IVendorService
    {
        Task<ResponseDto<List<VendorResponseDto>>> CreateAsync(VendorRequestDto model);
        
        Task<ResponseDto<VendorResponseDto>> GetByIdAsync(long id);
        Task<ResponseDto<List<VendorResponseDto>>> GetAllAsync();
        Task<ResponseDto<List<VendorResponseDto>>> UpdateAsync(VendorRequestDto model);
        Task<ResponseDto<List<VendorResponseDto>>> DeleteAsync(long vendorId);
    }
}