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
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> AddQuotationRequest(QuotationRequestDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var quotation = await _quotationService.AddQuotationRequest(model);
            if (!(quotation.Data == null))
            {
                response.Data = quotation.Data;
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
        [HttpGet]
        public async Task<ResponseDto<object>> QuotationList()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var quotation = await _quotationService.QuotationsListM();
            if (!(quotation.Data == null))
            {
                response.Data = quotation.Data;
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