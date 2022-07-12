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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ResponseDto<object>> CheckIn(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _service.CheckIn(model.Id);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                response.Message = types.Message;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Data = types.Data;
                response.Message = types.Message;
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> CheckOut(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _service.CheckOut(model.Id);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                response.Message = types.Message;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Data = types.Data;
                response.Message = types.Message;
                return response;
            }
        }
    }
}