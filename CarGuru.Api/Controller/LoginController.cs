using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using OpenTokSDK;
namespace CarGuru.Api.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        private readonly ILookUpsService _lookUpsService;
        public LoginController(ILoginService loginService,IConfiguration config, ILookUpsService lookUpsService)
        { 
            _loginService = loginService;
            _config = config;
            _lookUpsService = lookUpsService;
            //This is comment
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseDto<object>> Login(UserDeviceDto loginRequestDto, string returnUrl = null)
        {
            string testVar = string.Empty;
            //opentok credentials
            int ApiKey = _config.GetValue<int>("OpenTokKeys:ApiKey");
            string ApiSecret = _config.GetValue<string>("OpenTokKeys:ApiSecret");
            string SessionId = _config.GetValue<string>("OpenTokKeys:SessionId");
            double inOneDay = (DateTime.UtcNow.Add(TimeSpan.FromDays(1)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            OpenTok Open = new OpenTok(ApiKey, ApiSecret);
            
            ResponseDto<object> response = new ResponseDto<object>();
            var requestData = await FormatRequest(Request);
            var user = await _loginService.MLoginAsync(loginRequestDto);
            if (user.Status is 1 && !(user.Data is null))
            {
                var tokenString = GenerateJsonWebToken(user.Data);
                string token = Open.GenerateToken(SessionId, role: Role.PUBLISHER, expireTime: inOneDay, data: Convert.ToString(user.Data.UserId));
                user.Data.Token = tokenString;
                user.Data.OpenTokToken = token;
                response.Data = user.Data;
                if (user.Data.RoleId != 5 && user.Data.RoleId != 4 && user.Data.RoleId != 1) 
                {
                    response.Data = null;
                    response.Message = "User Not Allowed To Login Through mobile Applications";
                    response.Status = 0;
                    return response;
                }
                if (user.Data.RoleId == 5 && loginRequestDto.ApplicationType!="TechApp") 
                {
                    response.Data = null;
                    response.Message = "login failed";
                    response.Status = 0;
                    return response;
                }
                if (user.Data.RoleId == 1 && loginRequestDto.ApplicationType != "ManagementApp")
                {
                    response.Data = null;
                    response.Message = "login failed";
                    response.Status = 0;
                    return response;
                }
                if (user.Data.RoleId == 4 && loginRequestDto.ApplicationType != "ClientApp")
                {
                    response.Data = null;
                    response.Message = "login failed";
                    response.Status = 0;
                    return response;
                }
                return response;
            }
            else 
            {
                response.Message = "login failed";
                response.Status = 0;
                return response;
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public ResponseDto<object> Signup(UserSignupDto Dto)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var checkEmail = _lookUpsService.EmailCheck(Dto.Email);
            if(checkEmail.Data)
            {
                response.Data = "";
                response.Status = 0;
                response.Message = "Email already exist";
                return response;
            }
            var user = _loginService.SignUp(Dto);
            if (user.Status is 1 && !(user.Data is null))
            {
                //opentok credentials
                int ApiKey = _config.GetValue<int>("OpenTokKeys:ApiKey");
                string ApiSecret = _config.GetValue<string>("OpenTokKeys:ApiSecret");
                string SessionId = _config.GetValue<string>("OpenTokKeys:SessionId");
                double inOneDay = (DateTime.UtcNow.Add(TimeSpan.FromDays(1)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                OpenTok Open = new OpenTok(ApiKey, ApiSecret);
                string token = Open.GenerateToken(SessionId, role: Role.PUBLISHER, expireTime: inOneDay, data: Convert.ToString(user.Data.UserId));

                LoginResponseDto loginResponseDto = new LoginResponseDto()
                {
                    FirstName = user.Data.FirstName,
                    LastName = user.Data.LastName,
                    UserId = user.Data.UserId,
                    RoleId = user.Data.RoleId,
                    ProfileUrl = user.Data.ProfileUrl,
                    Email = user.Data.Email
                };

                var tokenString = GenerateJsonWebToken(loginResponseDto);

                // Assign Token and OpenTok Token
                loginResponseDto.Token = tokenString;
                loginResponseDto.OpenTokToken = token;
                loginResponseDto.PhoneNumber = Dto.PhoneNumber;

                response.Data = loginResponseDto;
                return response;
            }
            else
            {
                response.Message = "Signup failed";
                response.Status = 0;
                return response;
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public ResponseDto<object> GetUserRoles()
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var user = _loginService.UserRoles();
            if (user.Status is 1 && !(user.Data is null))
            {
                response.Data = user.Data;
                return response;
            }
            else
            {
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }
        [HttpPost]
        public ResponseDto<object> ForgotPassword(ForgotPasswordApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var status = _loginService.ForgotPassword(model.Email);
            if (status == true)
            {
                response.Message = "Your request has been sent forward";
                return response;
            }
            else
            {
                response.Message = "Something went wrong";
                response.Status = 0;
                return response;
            }
        }

        [HttpPost]
        public ResponseDto<object> MakeRequest(MakeRequestApiDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            var Status = _loginService.AddRequest(model);
            if (Status==true)
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
        [HttpPost]
        public async Task<IActionResult> Logout(LogoutRequestDto request)
        {
            return Ok(await _loginService.Logout(request));
        }
        [NonAction]
        public string GenerateJsonWebToken(LoginResponseDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  new List<Claim>()
                  {
                    new Claim(SessionStrings.UserName, user.FirstName + " " + user.LastName),
                    new Claim(SessionStrings.RoleId,user.RoleId.ToString()),
                    new Claim(SessionStrings.UserId,user.UserId.ToString())
                  },
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
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