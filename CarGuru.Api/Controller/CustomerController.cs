using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Api.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly ILookUpsService _lookUpsService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        public CustomerController(IUserService userService, ICustomerService customerService, ILookUpsService lookUpsService, ICustomerTypeService customerTypeService, IWebHostEnvironment environment)
        {
            _customerService = customerService;
            _customerTypeService = customerTypeService;
            _lookUpsService = lookUpsService;
            _userService = userService;
            _environment = environment;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> EditCustomer(EditCustomerRequestDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            //CustomerRequestDto model = JsonConvert.DeserializeObject<CustomerRequestDto>(vm.Customer);
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
            var result = await _customerService.EditCustomerAsync(model);
            if (!(result.Data == null))
            {
                response.Data = result.Data;
                response.Status = 1;
                return response;
            }
            else
            {
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }
        //[HttpPost]
        //public async Task<ResponseDto<object>> EditCustomer([FromForm] CustomerCustomRequestDto vm)
        //{
        //    ResponseDto<object> response = new ResponseDto<object>();
        //    CustomerRequestDto model = JsonConvert.DeserializeObject<CustomerRequestDto>(vm.Customer);
        //    if(!(vm.files is null) && vm.files.Length > 0)
        //    {
        //        if (!Directory.Exists(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\"))
        //        {
        //            Directory.CreateDirectory(_environment.ContentRootPath + "\\wwwroot\\resources\\client\\");
        //        }
        //        string FileName = DateTime.Now.ToString("yyyymmddMMss") + vm.files.FileName;
        //        string filePath = _environment.ContentRootPath + "\\wwwroot\\resources\\client\\" + FileName;
        //        using (FileStream fileStream = System.IO.File.Create(filePath))
        //        {
        //            await vm.files.CopyToAsync(fileStream);
        //            await fileStream.FlushAsync();
        //            model.ProfileUrl = EnviromentUrls.Api+"resources/client/" + FileName;
        //        }
        //    }
        //    var result = await _customerService.CreateAsync(model);
        //    if (!(result.Data ==null))
        //    {
        //        response.Data = result.Data;
        //        response.Status = 1;
        //        return response;
        //    }
        //    else
        //    {
        //        response.Message = "Something went wrong";
        //        response.Status = 0;
        //        return response;
        //    }
        //}
        //[ServiceFilter(typeof(APILog))]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseDto<object>> GetAllCustomerTypes()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var types = await _customerTypeService.GetAllAsync();
            if (!(types.Data == null))
            {
                response.Data = types.Data;
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
        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }
    }
}