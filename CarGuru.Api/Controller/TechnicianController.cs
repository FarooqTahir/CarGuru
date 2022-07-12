using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarGuru.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _environment;
        public TechnicianController(IEmployeeService employeeService, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _environment = environment;

        }
        [HttpPost]
        //public async Task<ResponseDto<object>> UpdateTechnician(UpdateEmployeeApiDto model)
        //public async Task<ResponseDto<object>> UpdateTechnician([FromForm] UpdateTechnicianRequestDto vm)
        public async Task<ResponseDto<object>> UpdateTechnician(UpdateEmployeeApiDto model)

        {
            ResponseDto<object> response = new ResponseDto<object>();
            //UpdateEmployeeApiDto model = JsonConvert.DeserializeObject<UpdateEmployeeApiDto>(vm.Technician);
            //if (!(vm.files is null) && vm.files.Length > 0)
            //{
            //    if (!Directory.Exists(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\"))
            //    {
            //        Directory.CreateDirectory(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\");
            //    }
            //    string FileName = DateTime.Now.ToString("yyyymmddMMss") + vm.files.FileName;
            //    string filePath = _environment.ContentRootPath + "\\wwwroot\\resources\\client\\" + FileName;
            //    using (FileStream fileStream = System.IO.File.Create(filePath))
            //    {
            //        await vm.files.CopyToAsync(fileStream);
            //        await fileStream.FlushAsync();
            //        model.ProfileUrl = EnviromentUrls.Api + "resources/client/" + FileName;
            //    }
            //}
            var result = await _employeeService.UpdateEmployeeApi(model);
            if (!(result == null))
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
        }
        [HttpPost]
        public async Task<ResponseDto<object>> GetProfileByEmployeeId(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = await _employeeService.GetEmployeeApi(model.Id);
            if (!(result == null))
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
        }
        [HttpPost]
        public ResponseDto<object> UpdateTechnicianLocation(TechnicianLocationApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var result = _employeeService.UpdateTechnicianLocation(model);
            if (!(result == null))
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
            else
            {
                response.Data = result.Data;
                response.Message = result.Message;
                return response;
            }
        }


    }
}