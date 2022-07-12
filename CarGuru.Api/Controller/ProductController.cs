using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILookUpsService _lookUpsService;
        public ProductController(ILookUpsService lookUpsService)
        {
            _lookUpsService = lookUpsService;
        }
        [HttpPost]
        public ResponseDto<object> ProductsListByCategoryId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _lookUpsService.GetAllProductsListApi(model.Id);
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
        public async Task<ResponseDto<object>> ProductsListByCategoryFilter(ProductListFilter model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _lookUpsService.GetAllProductsListFilterApi(model);
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