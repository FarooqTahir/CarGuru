using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Api.Controller
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _service;
        public VendorController(IVendorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ResponseDto<object>> GetAllVendorsList()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.GetAllAsync();
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
    }
}