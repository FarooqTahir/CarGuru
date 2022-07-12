using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nancy.Json;
using OpenTokSDK;
using SendGrid;

namespace CarGuru.Api.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILookUpsService _lookUpsService;
        private readonly IServiceOrderService _service;
        public ServiceOrderController(ICustomerService customerService, ILookUpsService lookUpsService, IServiceOrderService ServiceOrderervice)
        {
            _customerService = customerService;
            _lookUpsService = lookUpsService;
            _service = ServiceOrderervice;
        }

        [HttpPost]
        public async Task<ResponseDto<object>> ServiceOrderListByCustomer(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _customerService.ServicecOrderListByUserId(model.Id);
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseDto<object>> GetServiceTypes()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _lookUpsService.GetServiceTypesAsync();
            if (!(result == null))
            {
                response.Data = result.Data;
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
        public async Task<ResponseDto<object>> GetServiceOrderListByDate(ServiceOrderByDateDto Model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.ServicecOrderListByDate(Model.Date);
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

        [HttpPost]
        public async Task<ResponseDto<object>> ServiceOrderListByTechnician(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _customerService.ServicecOrderListByTechId(model.Id);
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

        [HttpPost]
        public async Task<ResponseDto<object>> ServiceOrderListForManagment(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _customerService.GetAllServicecOrderList();
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

        [HttpPost]
        public ResponseDto<object> ServiceOrderDropdownList(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _customerService.ServicecOrderListDropdownByUserId(model.Id);
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
        
        [HttpPost]
        public ResponseDto<object> AddProductInOrder(List<ProductInOrderApiDto> Products)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _service.AddProductInOrder(Products);
            if (!(result == null))
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
        }

        [HttpPost]
        public async Task<ResponseDto<object>> AddServiceOrder(ServiceOrderApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _customerService.AddServiceOrderM(model);
            if (!(result == null))
            {
                response.Data = result.Data;
                response.Message = result.Message;
                response.Status = result.Status;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Message = result.Message;
                response.Status = result.Status;
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetOrderDetailsById(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.GetInvoiceByOrderId(model.Id);
            if (!(result == null))
            {
                response.Data = result;
                response.Message = "Success";
                response.Status = 1;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "No Record Found";
                response.Status = 0;
                return response;
            }
        }
        [HttpPost]
        public ResponseDto<object> CompleteFromTechnicianByOrderId(IdDto model)
        {

            ResponseDto<object> response = new ResponseDto<object>();
            PaymentMessageDto pm = new PaymentMessageDto();

            int ApiKey = 46873904;
            string ApiSecret = "5c6c53ec2deede9654cc6f8fd32b764c70d9dbf1";
            string SessionId = "2_MX40Njg3MzkwNH5-MTU5NjYwODA1OTMwMH4wWjZCSHZUZ05HdVRnKzc0cXJpOWltOUl-fg";

            var result = _service.CompleteOrderFromTechnician(model.Id);
            if (result.Data!=null)
            {
                pm.InvoiceTotal = result.Data.TotalPrice.Value;
                pm.OrderId = result.Data.Id;
                pm.CustomerId = result.Data.CustomerId;

                var javaScriptSerializer = new JavaScriptSerializer();
                var dataString = javaScriptSerializer.Serialize(pm);

                SignalProperties signalProperties = new SignalProperties("data:"+ dataString, "type:ordercompleted");
                OpenTok Open = new OpenTok(ApiKey, ApiSecret);
                Open.Signal(SessionId, signalProperties);

                string connectionId = "CONNECTIONID";
                Open.Signal(SessionId, signalProperties, connectionId);

                response.Data = result;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = result.Message;
                response.Status = 0;
                return response;
            }
        }

    }    
}
