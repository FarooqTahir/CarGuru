using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using FluentFTP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Api.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        private readonly IWebHostEnvironment _environment;
        public ConversationController(IConversationService conversationService, IWebHostEnvironment environment)
        {
            _conversationService = conversationService;
            _environment = environment;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> AddMessage(MConversationDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.AddConversationMessage(model);
            if (!(message.Data == null))
            {
                response.Data = message.Data;
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
        public async Task<ResponseDto<object>> GetUsersChat(ConversationMessageRequestDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.GetChatMessagesByIdMobile(model.UserId,model.OtherUserId);
            if (!(message.Data == null))
            {
                response.Data = message.Data;
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
        public async Task<ResponseDto<object>> GetMessage(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.GetSingleMessage(model.Id);
            if (!(message.Data == null))
            {
                response.Data = message.Data;
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
        public async Task<ResponseDto<object>> EditMessage(ConversationDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.EditConversationMessage(model);
            if (!(message.Data == null))
            {
                response.Data = message.Data;
                response.Status = 1;
                response.Message = "Message Edited Successfully";
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
        public async Task<ResponseDto<object>> DeleteMessage(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.DeleteMessage(model.Id);
            if (message.Data)
            {
                response.Data = message.Data;
                response.Status = 1;
                response.Message = "Message Deleted Successfully";
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
        public async Task<ResponseDto<object>> ReadMessage(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.ReadMessage(model.Id);
            if (message.Data)
            {
                response.Data = message.Data;
                response.Status = 1;
                response.Message = "Message Read Successfully";
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
        public async Task<ResponseDto<object>> ReadConversation(ConversationMessageRequestDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var message = await _conversationService.ReadConversationMessage(model.UserId,model.OtherUserId);
            if (message.Data)
            {
                response.Data = message.Data;
                response.Status = 1;
                response.Message = "Message Read Successfully";
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
        public async Task<string> UploadFile([FromForm] ConversationFileDto vm)
        {
            string FinalUrl = "";
            if (!(vm.files is null) && vm.files.Length > 0)
            {
                if (!Directory.Exists(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\"))
                {
                    Directory.CreateDirectory(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\");
                }

                string FileName = DateTime.Now.ToString("yyyymmddMMss") + vm.files.FileName;
                string filePath = _environment.ContentRootPath + "\\wwwroot\\resources\\client\\" + FileName;
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    await vm.files.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    FinalUrl = EnviromentUrls.Api + "resources/client/" + FileName;
                }
            }
            return FinalUrl;
        }

        [HttpGet]
        public ResponseDto<object> GetAgents()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _conversationService.AgentsAvailable();
            if (result.Count>0)
            {
                response.Data = result;
                response.Status = 1;
                response.Message = "Success";
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