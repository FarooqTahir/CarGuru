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
    //[Authorize]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IServiceOrderService _ServiceOrderervice;
        private readonly IManagementService _managementService;
        private readonly IUserService _userService;

        public DashboardController(IServiceOrderService ServiceOrderervice,IManagementService managementService, IUserService userService)
        {
            _ServiceOrderervice = ServiceOrderervice;
            _managementService = managementService;
            _userService = userService;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> TechnichianDashboardData(TechDAshboardApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _ServiceOrderervice.GetTechDashboardData(model.TechnicianId, model.Date);
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
        public async Task<ResponseDto<object>> CustomerProfileList()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _managementService.CustomerProfileList();
            if (!(result == null))
            {
                response.Data = result.Data;
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
        public async Task<ResponseDto<object>> GetEmployeeRoles()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _managementService.GetEmployeeRoles();
            if (!(result == null))
            {
                response.Data = result.Data;
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
        public ResponseDto<object> GetEmployeeList(IdDto request)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            int RoleId = Convert.ToInt32(request.Id);
            var result = _userService.UsersListByRoleId(RoleId);
            if (!(result == null))
            {
                response.Data = result.Data;
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
        public async Task<ResponseDto<object>> ManagmentDashboard()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result =  await _managementService.ManagementDashboardAnalytics(null, null);
            if (!(result == null))
            {
                response.Data = result.Data;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "No Record Found";
                return response;
            }
        }
    }
}