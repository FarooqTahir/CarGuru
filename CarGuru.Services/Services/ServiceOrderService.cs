using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ServiceOrderService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> GetAllServicecOrderListByAgentId(long agentId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]",
                   commandType: CommandType.StoredProcedure);
                var response = result.Where(x => x.AgentId == agentId).ToList().OrderBy(x => x.CreatedDate).ToList();
                if (!(response is null))
                {
                    return response;
                }
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
        public async Task<List<LeadsResponseDto>> GetAllLeads(long? AgentId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                if (AgentId != 0)
                {
                    var result = await conn.QueryAsync<LeadsResponseDto>(sql: "[dbo].[spGetLeads]", param: new { AgentId = AgentId },
                   commandType: CommandType.StoredProcedure);
                    if (!(result is null))
                    {
                        return result.ToList();
                    }
                }
                else 
                {
                    var result = await conn.QueryAsync<LeadsResponseDto>(sql: "[dbo].[spGetLeads]",
                    commandType: CommandType.StoredProcedure);
                    if (!(result is null))
                    {
                        return result.ToList();
                    }
                }
                
                return new List<LeadsResponseDto>();
            }
        }
        public ResponseDto<List<ProductInOrderApiDto>> AddProductInOrder(List<ProductInOrderApiDto> Products)
        {
            if (!(Products is null) && Products.Count > 0)
            {

                var mapList = _mapper.Map<List<ProductsInServiceOrders>>(Products);
                foreach (var item in mapList)
                {
                    var productService = _db.ProductsInServiceOrders.FirstOrDefault(a => a.ProductId == item.ProductId && a.ServiceOrderId == item.ServiceOrderId);
                    if(productService is null)
                    {
                        _db.ProductsInServiceOrders.Add(item);
                    }
                }
                //_db.ProductsInServiceOrders.AddRange(mapList);
                decimal total = 0;
                var ServiceOrderId = Products[0].ServiceOrderId;
                //string ProductIds = string.Join(",", Products.Select(x => x.ProductId));
                //if (ProductIds.Length > 0)
                foreach(var ProductIds in Products)
                {
                    using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                    {
                        var result = conn.Query<Products>(sql: "[dbo].[spMaintainStock]", param: new { List = Convert.ToString(ProductIds.ProductId) },
                           commandType: CommandType.StoredProcedure);
                        var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                        if (!(response is null) && response.Count > 0)
                        {
                            Notifications noti = new Notifications();
                            foreach (var item in response)
                            {
                                var Notification = new Notifications()
                                {
                                    NotificationTo = AdminData.Id,
                                    NotificationFrom = 0,
                                    Message = item.Name + "has reached its dead stock",
                                    TypeId = Convert.ToInt32(NotificationTypes.NewQuotationRequest),
                                    CreatedDate = DateTime.UtcNow
                                };
                                _db.Notifications.Add(Notification);
                            }
                        }

                    }
                }
                foreach (var item in Products)
                {
                    total = total + item.Price;
                }
                var Order = _db.ServiceOrders.FirstOrDefault(x => x.Id == ServiceOrderId);
                if (!(Order is null))
                {
                    Order.TotalPrice = Order.TotalPrice + total;
                    _db.Entry(Order).State = EntityState.Modified;
                }
                var data = _db.SaveChanges();
                if (data > 0)
                {
                    return new ResponseDto<List<ProductInOrderApiDto>>() { Data = Products, Message = "Successfully Added" };
                }
                else
                {
                    return new ResponseDto<List<ProductInOrderApiDto>>() { Data = null, Message = "Somthing Went Wrong" };
                }
            }
            else
            {
                return new ResponseDto<List<ProductInOrderApiDto>>() { Data = null, Message = "Somthing Went Wrong" };
            }
            
        }
        public async Task<InvoiceApiDto> GetInvoiceByOrderId(long orderId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<String>(sql: "[dbo].[spGetInvoiceByOrdeId]",param:new {ServiceOrderId= orderId },
                   commandType: CommandType.StoredProcedure);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var rec in result)
                {
                    stringBuilder.Append(rec);
                }
                return JsonConvert.DeserializeObject<InvoiceApiDto>(Convert.ToString(stringBuilder));
            }
        }
        public async Task<List<InvoiceListDto>> GetAllInvoicelist(long? AgentId,long? TechId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<InvoiceListDto>(sql: "[dbo].[GetAllInvoiceList]", param: new { TechId = TechId, AgentId = AgentId },
                   commandType: CommandType.StoredProcedure);
                if (!(result is null))
                {
                    var re = result.Where(x=>x.OrderStatusId == OrderStatus.Completed).ToList();
                    return re;
                }
                return new List<InvoiceListDto>();
            }
        }
        public async Task<List<InvoiceListDto>> GetAlllistForCalanders(long? AgentId, long? TechId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<InvoiceListDto>(sql: "[dbo].[GetAllInvoiceList]", param: new { TechId = TechId, AgentId = AgentId },
                   commandType: CommandType.StoredProcedure);
                if (!(result is null))
                {
                    return result.ToList();
                }
                return new List<InvoiceListDto>();
            }
        }
        public async Task<List<TechDashbordApiDto>> GetTechDashboardData(long TechId, DateTime Date)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<String>(sql: "[dbo].[spGetTechDashbordData]", param: new { TechId = TechId, InputDate = Date },
                   commandType: CommandType.StoredProcedure);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var rec in result)
                {
                    stringBuilder.Append(rec);
                }
                return JsonConvert.DeserializeObject<List<TechDashbordApiDto>>(Convert.ToString(stringBuilder));
            }
        }
        public ResponseDto<ServiceOrderBaseDto> CompleteOrderFromTechnician(long orderId)
        {
            var DbOrder = _db.ServiceOrders.Where(x => x.Id == orderId).FirstOrDefault();
            if (DbOrder.OrderStatusId == OrderStatus.CompletedByTechnician || DbOrder.OrderStatusId == OrderStatus.Completed) { return new ResponseDto<ServiceOrderBaseDto> { Data = null, Message = "Order Already Completed" }; }
            var Customer = _db.Customers.Where(x => x.Id == DbOrder.CustomerId).FirstOrDefault();

            var Notification = new Database.Models.Notifications()
            {
                NotificationTo = Customer.UserId,
                NotificationFrom = DbOrder.AssignedToId.Value,
                Message = "Order Completed",
                TypeId = Convert.ToInt32(NotificationTypes.OrderCompletedByTechnician),
                CreatedDate =DateTime.UtcNow
            };
            _db.Notifications.Add(Notification);
            var UserDevices = _db.UserDevices.Where(x => x.UserId == Customer.UserId).ToList();
           
            if (!(UserDevices is null) && UserDevices.Any())
            {
                foreach (var device in UserDevices)
                {
                    Common.SendPushNotification(device.DeviceToken, "Order Completed");
                }
            }

            DbOrder.OrderStatusId = OrderStatus.CompletedByTechnician;
            DbOrder.UpdatedDate = DateTime.UtcNow;
            _db.Entry(DbOrder).State = EntityState.Modified;
            var result = _db.Entry(DbOrder).State = EntityState.Modified;
            if (result > 0) 
            {
                var Result = _mapper.Map<ServiceOrders,ServiceOrderBaseDto>(DbOrder);
                Result.CustomerId = Customer.UserId;
                return new ResponseDto<ServiceOrderBaseDto> { Data = Result, Message = "Success" };
            }
            return new ResponseDto<ServiceOrderBaseDto>() { Data=null,Message="Something went wrong"};
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> SearchOrder(string search)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]", param: new { Name = search },
                   commandType: CommandType.StoredProcedure);
                var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                if (response != null) 
                {
                    return response;
                }
                //if (search == "" || search == null) 
                //{
                //    return response;
                //}
                //if (search != "" || search != null)
                //{
                //    var Products = from Order in response
                //                   where Order.Customer.Contains(search) || Order.ServiceOrderNo.ToString().Contains(search)
                //                   select Order;
                //    var List = _mapper.Map<List<ServiceOrdersListSpResponseDto>>(Products.ToList());
                //    return List;
                //}                
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByDate(DateTime Date)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]",
                    commandType: CommandType.StoredProcedure);
                var response = result.Where(x => x.ScheduleDateTime.Date == Date.Date).OrderBy(x => x.CreatedDate).ToList();
                if (!(response is null))
                {
                    return response;
                }
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
    }
}
