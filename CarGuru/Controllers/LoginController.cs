using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenTokSDK;

namespace CarGuru.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILookUpsService _lookUpsService;
        private readonly ICustomerService _customerService;
        private IConfiguration _config;
        private readonly INotificationService _notificationService;

        public LoginController(ILoginService loginService, ILookUpsService lookUpsService, ICustomerService customerService, IConfiguration config,INotificationService notificationService)
        {
            _loginService = loginService;
            _lookUpsService = lookUpsService;
            _customerService = customerService;
            _config = config;
            _notificationService = notificationService;
        }
        
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl ?? Url.Content("~/");


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto, string returnUrl = null)
        {
            //opentok credentials
            int ApiKey = _config.GetValue<int>("OpenTokKeys:ApiKey");
            string ApiSecret = _config.GetValue<string>("OpenTokKeys:ApiSecret");
            string SessionId = _config.GetValue<string>("OpenTokKeys:SessionId");
            returnUrl ??= Url.Content("~/");
            var userRole = "";

            var user = await _loginService.LoginAsync(loginRequestDto);
            if (user.Status is 1&& !(user.Data is null))
            {  

                    if (user.Data.RoleId == Convert.ToInt32(UserRoles.Management))
                        userRole = UserRoleStrings.Management;

                    if (user.Data.RoleId == Convert.ToInt32(UserRoles.Agent))
                        userRole = UserRoleStrings.Agent;

                    if (user.Data.RoleId == Convert.ToInt32(UserRoles.Supervisor))
                        userRole = UserRoleStrings.Supervisor;

                string token = "";
                DateTime tokenExpiry = DateTime.UtcNow;
                double inOneDay = (DateTime.UtcNow.Add(TimeSpan.FromDays(1)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                OpenTok Open = new OpenTok(ApiKey, ApiSecret);
                token = Open.GenerateToken(SessionId, role: Role.PUBLISHER, expireTime: inOneDay, data: Convert.ToString(user.Data.UserId));
                var claims = new List<Claim>
                        {
                            new Claim(SessionStrings.UserId, Convert.ToString(user.Data.UserId)),
                            new Claim(SessionStrings.UserRoleId, Convert.ToString(user.Data.RoleId)),
                            new Claim(SessionStrings.UserName, ""+user.Data.FirstName+" "+user.Data.LastName+""),
                            new Claim(SessionStrings.ProfilePicture, (string.IsNullOrEmpty(user.Data.ProfileUrl))?"":user.Data.ProfileUrl),
                            new Claim(SessionStrings.TokenSession, token),
                            new Claim(SessionStrings.SessionId, SessionId),
                            new Claim(ClaimTypes.Role, userRole)
                        };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));


                if (user.Data.RoleId == Convert.ToInt32(UserRoles.Management))
                        return RedirectToAction("Dashboard", "Management");

                if (user.Data.RoleId == Convert.ToInt32(UserRoles.Agent))
                    return RedirectToAction("Dashboard", "Agent");

                if (user.Data.RoleId == Convert.ToInt32(UserRoles.Supervisor))
                    return RedirectToAction("Dashboard", "Supervisor");
              
            }
            TempData["custom-error"] = ResponseStrings.InvalidCredentials;
            return RedirectToAction(nameof(LoginController.Login), "Login");
        }
        public IActionResult SignUp()
        {
            var model = new SignUpViewModel();
            var questions = _lookUpsService.GetLookupValueWithType("SecurityQuestion");
            if (questions.Status is 1)
                if (questions.Data.Any())
                    model.SecurityQuestions.AddRange(questions.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));



            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetNotification(long userId)
        {
            var data = await _notificationService.List(userId);
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> ReadNotification(long userId)
        {
            var data = await _notificationService.Read(userId);
            return Json(data.Data);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
           
            if (model.IsCustomer)
            {
                var requestDto = new CustomerRequestDto() { User = model.Customer };
                requestDto.User.RoleId = Convert.ToInt32(UserRoles.Customer);
                var response=await _customerService.CreateAsync(requestDto);
                if (response.Data != null)
                {
                    return RedirectToAction("Login");
                }
            }          

            var vm = new SignUpViewModel();
            var questions = _lookUpsService.GetLookupValueWithType("SecurityQuestion");
            if (questions.Status is 1)
                if (questions.Data.Any())
                    model.SecurityQuestions.AddRange(questions.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(LoginController.Login), "Login");
        }

        [HttpPost]
        public IActionResult EmailCheck(string email)
        {
            var result = _lookUpsService.EmailCheck(email);
            return Json(result.Data);
        }
        [HttpGet]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

    }
}