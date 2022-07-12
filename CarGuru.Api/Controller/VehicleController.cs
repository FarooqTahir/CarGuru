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
    public class VehicleController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public VehicleController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ResponseDto<object> AddVehicle(CustomerVehicleDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = _customerService.AddVehicle(model);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "Something went wrong";
                return response;
            }

        }
        [HttpPost]
        public async Task<ResponseDto<object>> EditVehicle(CustomerVehicleDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _customerService.EditVehicle(model);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "Something went wrong";
                return response;
            }

        }
        [HttpPost]
        public async Task<ResponseDto<object>> DeleteVehicle(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _customerService.DeleteVehicles(model.Id);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "Something went wrong";
                return response;
            }

        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetVehicleListByUserId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _customerService.GetVehicleByUserId(model.Id);
            if (!(types.Data == null))
            {
                response.Data = types.Data;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Status = 0;
                response.Message = "Something went wrong";
                return response;
            }

        }
    }
}