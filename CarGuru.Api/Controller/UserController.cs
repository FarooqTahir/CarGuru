using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProfileService _service;
        public UserController(IUserProfileService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetUserProfileByUserId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.GetByUserIdAsync(model.Id);
            if (!(result == null))
            {
                response.Data = result;
                response.Message = "success";
                response.Status = 1;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> UpdateUserProfile(UserUpdateModelDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.UpdateProfileAsync(model);
            if (!(result == null))
            {
                response.Data = result;
                response.Message = "success";
                response.Status = 1;
                return response;
            }
            else
            {
                response.Data = result;
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }
    }
}