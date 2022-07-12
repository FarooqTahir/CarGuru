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
    public class InventoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public InventoryController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetAllInventory(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var dbList = await _productService.GetAllAsync("");
            var Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            if (!(Products == null))
            {
                response.Data = Products;
                return response;
            }
            else
            {
                response.Data = Products;
                response.Message = "No Record Found";
                return response;
            }
        }
    }
}