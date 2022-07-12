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
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ILookUpsService _lookUpsService;
        public ProductCategoriesController(ILookUpsService lookUpsService)
        {
            _lookUpsService = lookUpsService;
        }
        [HttpGet]
        public ResponseDto<object> ProductCategoriesList()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _lookUpsService.GetAllCategories();
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