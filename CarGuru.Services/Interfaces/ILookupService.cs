using CarGuru.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.ApisDtos;
using System.Threading.Tasks;
using CarGuru.Database.Dtos.RequestDto;

namespace CarGuru.Services.Interfaces
{
    public interface ILookUpsService
    {
        ResponseDto<List<LookupResponseDto>> GetLookupValueWithType(string type);
        Task<ResponseDto<List<ServiceTypeDto>>> GetServiceTypesAsync();
        Task<ResponseDto<GetAllProductsListFilter>> GetAllProductsListFilterApi(ProductListFilter filter);
        ResponseDto<List<ProductResponseDto>> GetAllProductsList();
        ResponseDto<bool> EmailCheck(string email);
        ResponseDto<List<RolesResponseDto>> GetAllRoles();
        ResponseDto<UserResponseDto> GetUserByUserId(long UserId);
        ResponseDto<CustomerResponseDto> GetCustomerByUserId(long UserId);
        ResponseDto<List<ProductListDto>> GetAllProductsListApi(long CategoryId);
        ResponseDto<List<ProductCategoriesApiDto>> GetAllCategories();
    }
}
