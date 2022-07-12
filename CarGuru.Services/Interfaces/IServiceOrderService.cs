using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IServiceOrderService
    {
        Task<List<ServiceOrdersListSpResponseDto>> GetAllServicecOrderListByAgentId(long agentId);
        ResponseDto<List<ProductInOrderApiDto>> AddProductInOrder(List<ProductInOrderApiDto> Products);
        Task<InvoiceApiDto> GetInvoiceByOrderId(long orderId);
        Task<List<InvoiceListDto>> GetAllInvoicelist(long? AgentId, long? TechId);
        Task<List<TechDashbordApiDto>> GetTechDashboardData(long TechId, DateTime Date);
        Task<List<LeadsResponseDto>> GetAllLeads(long? AgentId);
        Task<List<InvoiceListDto>> GetAlllistForCalanders(long? AgentId, long? TechId);
        ResponseDto<ServiceOrderBaseDto> CompleteOrderFromTechnician(long orderId);
        Task<List<ServiceOrdersListSpResponseDto>> SearchOrder(string search);
        Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByDate(DateTime Date);

    }
}
