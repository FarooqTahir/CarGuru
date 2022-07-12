using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;

namespace CarGuru.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ResponseDto<List<ProductCategoryResponseDto>>> CreateAsync(ProductCategoryRequestDto model);
        Task<ResponseDto<ProductCategoryResponseDto>> GetByIdAsync(long id);
        ResponseDto<List<ProductCategoryResponseDto>> GetAllAsync();
        Task<ResponseDto<List<ProductSubCategoryRequestDto>>> GetAllSubCategoryIdCategoryIdAsync(int categoryId);
        Task<ResponseDto<List<ProductCategoryResponseDto>>> UpdateAsync(ProductCategoryRequestDto model);
        Task<ResponseDto<List<ProductCategoryResponseDto>>> DeleteAsync(long Id);
        Task<ResponseDto<ProductCategoryResponseDto>> DeleteSubCategoryAsync(long Id);
    }
}