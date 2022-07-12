using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;

namespace CarGuru.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseDto<CustomerResponseDto>> CreateAsync(CustomerRequestDto model);
        Task<ResponseDto<CustomerResponseDto>> EditCustomerAsync(EditCustomerRequestDto model);
        Task<ResponseDto<CustomerResponseDto>> CreateWithVehicles(CustomerRequestDto model, List<CustomerVehicleRequestDto> Vehicles, long CreatedBy);
        List<UserResponseDto> GetAllCustomer(string name);
        ResponseDto<CustomerResponseDto> CreatServiceOrder(ServiceOrderRequestDto model, long CreatedBy);
        ResponseDto<CustomerResponseDto> EditServiceOrder(ServiceOrderRequestDto model, long UpdatedBy);
        ResponseDto<List<CustomerVehicleResponseDto>> GetAllVehiclesByCustomerId(long? UserId, long? CustomerId);
        List<UserResponseDto> UpdateCustomer(CustomerRequestDto model);
        ResponseDto<ServiceOrderRequestDto> GetServiceOrderByCustomerId(long Id, long serviceOrderId);
        ResponseDto<List<CustomerVehicleResponseDto>> AddVehicle(CustomerVehicleDto model);
        Task<ResponseDto<List<CustomerVehicleResponseDto>>> EditVehicle(CustomerVehicleDto model);
        Task<ResponseDto<List<CustomerVehicleResponseDto>>> GetVehicleByUserId(long id);
        Task<ResponseDto<List<CustomerVehicleResponseDto>>> DeleteVehicles(long Id);
        Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByUserId(long UserId);
        Task<List<ServiceOrdersListUpdatedSpResponseDto>> ServicecOrderListByUserIdUpdated(long UserId);
        Task<List<ServiceOrdersListSpResponseDto>> GetAllServicecOrderList();
        CustomerResponseDto GetCustomerByUserId(long UserId);
        List<long> ServicecOrderListDropdownByUserId(long UserId);
        ResponseDto<CustomerVehicleResponseDto> GetVehicleById(long id);
        Task<ResponseDto<ServiceOrderApiDto>> AddServiceOrderM(ServiceOrderApiDto model);
        Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByTechId(long UserId);
        ResponseDto<ServiceOrderRequestDto> GetServiceOrderByCustomerIdM(long Id, long serviceOrderId);
    }
}