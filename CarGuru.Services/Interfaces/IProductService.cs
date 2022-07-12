using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;

namespace CarGuru.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductResponseDto>>> CreateAsync(ProductRequestDto model);
        Task<ResponseDto<List<ProductResponseDto>>> UpdateAsync(ProductRequestDto model);
        Task<ResponseDto<ProductResponseDto>> GetByIdAsync(long id);
        Task<ResponseDto<List<ProductResponseDto>>> GetAllAsync(string name);
        Task<ResponseDto<List<ProductResponseDto>>> GetAllByCategoryIdAsync(int categoryId);
        Task<ResponseDto<List<ProductResponseDto>>> GetAllByFilterAsync(string query);
        Task<ResponseDto<List<ProductResponseDto>>> DeleteProduct(long ProductId);
        ResponseDto<List<FleetResponseDto>> GetAllFleets();
        Task<ResponseDto<List<ProductResponseDto>>> SearchProductByName(string Name);
    }
}