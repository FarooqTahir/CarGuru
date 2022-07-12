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
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _service;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _service = feedbackService;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> AddFeedback(FeedbackRequestDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.CreateAsync(model);
            if (!(result.Data == null))
            {
                response.Data = result.Data;
                response.Status = 1;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Status = 0;
                response.Message = result.Message;
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> FeedbackListByTechnicianId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _service.TechnicianFeedbak(model.Id);
            if (!(result.Data == null))
            {
                response.Data = result.Data;
                response.Status = 1;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Status = 0;
                response.Message = result.Message;
                return response;
            }
        }
    }
}