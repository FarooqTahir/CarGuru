using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarGuru.Services.Interfaces;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;

namespace CarGuru.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _Service;
        public NotificationController(INotificationService Service)
        {
            _Service = Service;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetNotificationsByUserId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var obj = await _Service.List(model.Id);
            if (!(obj == null))
            {
                response.Data = obj.Data;
                response.Message = obj.Message;
                response.Status = obj.Status;
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
        public async Task<ResponseDto<object>> ReadNotificationByUserId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var obj = await _Service.Read(model.Id);
          
                response.Data = obj.Data;
                response.Message = obj.Message;
                response.Status = obj.Status;
                return response;
        }
    }
}