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
    public class HelpController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public HelpController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ResponseDto<object> MakeRequest(MakeRequestApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var Status = _loginService.AddRequest(model);
            if (Status == true)
            {
                response.Status = 1;
                response.Message = "Request has been successfully forwarded";
                return response;
            }
            else
            {
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }
    }
}