using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IServiceOrderService _ServiceOrderService;
        public InvoiceController(ICustomerService customerService, IServiceOrderService ServiceOrderervice)
        {
            _customerService = customerService;
            _ServiceOrderService = ServiceOrderervice;
        }

        [HttpPost]
        public ResponseDto<object> GetInvoiceByCustomerId(InvoiceRequestApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var obj = _customerService.GetServiceOrderByCustomerIdM(model.CustomerId, model.ServiceOrderId);
            if (!(obj == null))
            {
                InvoiceResponseDto result = new InvoiceResponseDto();
                foreach (var item in obj.Data.Products)
                {
                    result.ProductCost = result.ProductCost + item.Price;
                }
                foreach (var item in obj.Data.Services)
                {
                    result.ServiceCharges = result.ServiceCharges + item.Price;
                }
                result.Total = result.ProductCost + result.ServiceCharges;
                response.Data = obj.Data;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "No Record Found";
                return response;
            }
        }

        [HttpPost]
        public async Task<ResponseDto<object>> GetInvoiceListByTechUserId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _ServiceOrderService.GetAllInvoicelist(null, model.Id);
            if (!(result == null))
            {
                response.Data = result;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "No Record Found";
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetInvoiceListForMangment(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _ServiceOrderService.GetAllInvoicelist(null, null);
            if (!(result == null))
            {
                response.Data = result;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "No Record Found";
                return response;
            }
        }

        [HttpPost]
        public async Task<ResponseDto<object>> GetInvoiceByOrderId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _ServiceOrderService.GetInvoiceByOrderId(model.Id);
            if (!(result == null))
            {
                response.Data = result;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "No Record Found";
                return response;
            }
        }

        [HttpPost]
        public async Task<ResponseDto<object>> GetAllInvoiceListByCustomerId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _customerService.ServicecOrderListByUserIdUpdated(model.Id);
            if (!(result == null))
            {
                response.Data = result;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "No Record Found";
                return response;
            }
        }
    }
}