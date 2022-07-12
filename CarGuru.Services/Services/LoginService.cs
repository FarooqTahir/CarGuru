using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CarGuru.Services.Services
{
    public class LoginService:ILoginService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private static IHostingEnvironment _hostingEnvironment;

        public LoginService(ApplicationDbContext dbContext,IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public async Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto model)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x =>
                x.Email == model.Email && x.Password.Trim() == model.Password.Trim());
            var mappedResponse = _mapper.Map<LoginResponseDto>(user);
            return new ResponseDto<LoginResponseDto>(){Data = mappedResponse};
        }
        public async Task<ResponseDto<LoginResponseDto>> MLoginAsync(UserDeviceDto model)
        {
            var data = _db.Database.GetDbConnection().ConnectionString;
            var user = await _db.Users.FirstOrDefaultAsync(x =>
                x.Email == model.Email && x.Password.Trim() == model.Password.Trim());
            if (!(user is null))
            {
                // Checking that User has Login From Mobile
                var isEntryExist = await _db.UserDevices.FirstOrDefaultAsync(x => x.UserId == user.UserId && x.DeviceTypeId == model.DeviceTypeId && x.DeviceToken.Equals(model.DeviceToken));
                if (isEntryExist is null)
                {
                    //authUserDto.UserId = rec.UserId;
                    var mapObj = _mapper.Map<UserDevices>(model);
                    mapObj.UserId = user.UserId;
                    _db.UserDevices.Add(mapObj);
                    await _db.SaveChangesAsync();
                }
            }
            var mappedResponse = _mapper.Map<LoginResponseDto>(user);
            return new ResponseDto<LoginResponseDto>() { Data = mappedResponse };
        }
        public async Task<ResponseDto<bool>> Logout(LogoutRequestDto request)
        {
            try
            {
                var userLogout = _db.UserDevices.FirstOrDefault(a => a.UserId == request.UserId && a.DeviceTypeId == request.DeviceTypeId && a.DeviceToken == request.DeviceToken);
                if (!(userLogout is null))
                {
                    _db.UserDevices.Remove(userLogout);
                    await _db.SaveChangesAsync();
                }
                return new ResponseDto<bool>()
                {
                    Data = true
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ResponseDto<UserResponseDto> SignUp(UserSignupDto model)
        {
            var DbObj = _mapper.Map<UserSignupDto, Users>(model);
            DbObj.CreatedDate = DateTime.UtcNow;
            _db.Users.Add(DbObj);
            _db.SaveChanges();
            if (model.RoleId == 2) 
            {
                var dbTechDetail = new TechnicianDetails();
                dbTechDetail.Fees = 0;
                dbTechDetail.TechnichainId = DbObj.UserId;
                if (model.Fees != null) 
                {
                    dbTechDetail.Fees = model.Fees.Value;
                }
                _db.TechnicianDetails.Add(dbTechDetail);
                _db.SaveChanges();
            }else if (model.RoleId == 4)
            {
                var mappedObject = new Customers();
                mappedObject.User = new Users();
                mappedObject.User = DbObj;
                mappedObject.User.CreatedDate = DateTime.UtcNow;
                mappedObject.UserId = DbObj.UserId;
                mappedObject.CustomerTypeId = model.CustomerTypeId;
                mappedObject.NoOfVehicles = 0;
                _db.Customers.Add(mappedObject);
                _db.SaveChanges();
            }
            if (!string.IsNullOrEmpty(model.DeviceToken))
            {
                var UserDevice = new UserDevices();
                UserDevice.UserId = DbObj.UserId;
                UserDevice.DeviceTypeId = model.DeviceTypeId;
                UserDevice.DeviceToken = model.DeviceToken;
                _db.UserDevices.Add(UserDevice);
                _db.SaveChanges();
            }
            var mappedResponse = _mapper.Map<UserResponseDto>(DbObj);
            return new ResponseDto<UserResponseDto>() { Data = mappedResponse };
        }
        public ResponseDto<List<Roles>> UserRoles()
        {
            var userRoles =  _db.Roles.ToList();
            
            return new ResponseDto<List<Roles>>() { Data = userRoles };
        }
        public bool ForgotPassword(string email)
        {
            var DbUser = _db.Users.Where(x=>x.Email.Equals(email) && x.IsActive==true).FirstOrDefault();
            var newPassword = Common.RandomPassword(8);
            if (!(DbUser == null)) 
            {
                DbUser.Password = newPassword;
                _db.SaveChanges();
                SendNewPassword(DbUser.Email,newPassword);
                return true;
            }
            return false;
        }
        public void SendNewPassword(string Email,string password) 
        {
            string emailTemplateBody;
            var env = _hostingEnvironment.ContentRootPath+"\\EmailTemplates\\ForgotPassword.txt";
            emailTemplateBody = File.ReadAllText(env);
            string messageBody = string.Format(emailTemplateBody,
                password
            );
            EmailDto Mail = new EmailDto() {
                Body = messageBody,
                Subject = "Password Changed Successfully",
            };
            Mail.ToEmails.Add(Email);
            EmailSender.SendEmailAsync(Mail);
        }
        public bool AddRequest(MakeRequestApiDto model)
        {
            var DbRequest = _mapper.Map<HelpRequests>(model);
            DbRequest.CreatedDate = DateTime.UtcNow;
            DbRequest.IsActive = true;
            _db.HelpRequests.Add(DbRequest);
            _db.SaveChanges();
            if (DbRequest.Id > 0) { return true; }
            return false;
        }


    }
}