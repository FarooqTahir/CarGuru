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
    public class EmployeeService:IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private static IHostingEnvironment _hostingEnvironment;


        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<EmployeeResponseDto>>> CreateAsync(EmployeeRequestDto model)
        {
            var mappedObject = _mapper.Map<EmployeeRequestDto, Employees>(model);
            mappedObject.User.CreatedDate = DateTime.UtcNow;
            _db.Employees.Add(mappedObject);
            await _db.SaveChangesAsync();
            var dbObject = await _db.Employees.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == mappedObject.Id);
            SendPassword(mappedObject.User.Email, mappedObject.User.Password);
            var mappedResponse = _mapper.Map<Employees, EmployeeResponseDto>(dbObject);

            var Employees = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
            if (Employees is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
            var mappedList = _mapper.Map<List<EmployeeResponseDto>>(Employees);
            return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedList };
        }

        public async Task<ResponseDto<List<EmployeeResponseDto>>> UpdateAsync(EmployeeRequestDto model)
        {
            var dbObject = await _db.Employees.Include(x=>x.User).FirstOrDefaultAsync(x => x.UserId == model.User.UserId);
            if (!(dbObject is null))
            {
                dbObject.User.Address = model.User.Address;
                dbObject.User.Email = model.User.Email;
                dbObject.User.Address = model.User.Address;
                dbObject.User.FirstName = model.User.FirstName;
                dbObject.User.LastName = model.User.LastName;
                dbObject.User.PhoneNumber = model.User.PhoneNumber;
                dbObject.User.RoleId = model.User.RoleId;
                dbObject.User.Password = model.User.Password;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var EmployeeList = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
                if (EmployeeList is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<EmployeeResponseDto>>(EmployeeList);
                return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedList };
            }
            var Employees = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
            if (Employees is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<EmployeeResponseDto>>(Employees);
            return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedObject };
        }
        public void SendPassword(string Email, string password)
        {
            string emailTemplateBody;
            var env = _hostingEnvironment.WebRootPath + "\\EmailTemplates\\ForgotPassword.txt";
            emailTemplateBody = File.ReadAllText(env);
            string messageBody = string.Format(emailTemplateBody,
                password
            );
            EmailDto Mail = new EmailDto()
            {
                Body = messageBody,
                Subject = "Password Changed Successfully",
            };
            Mail.ToEmails.Add(Email);
            EmailSender.SendEmailAsync(Mail);
        }
        public async Task<ResponseDto<List<EmployeeResponseDto>>> DeleteEmployee(long Id)
        {
            var dbObject = await _db.Employees.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == Id);
            if (!(dbObject is null))
            {
                dbObject.User.IsActive = false;
                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var EmployeeList = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
                if (EmployeeList is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<EmployeeResponseDto>>(EmployeeList);
                return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedList };
            }
            var Employees = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
            if (Employees is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<EmployeeResponseDto>>(Employees);
            return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedObject };
        }

        public async Task<ResponseDto<EmployeeResponseDto>> GetByIdAsync(long id)
        {
            var dbObject = await _db.Employees.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == id);
            if (dbObject is null) return new ResponseDto<EmployeeResponseDto>() {Status = 0, Data = null};
            var mappedObject = _mapper.Map<EmployeeResponseDto>(dbObject);
            return new ResponseDto<EmployeeResponseDto>() { Data = mappedObject };
        }

        public async Task<ResponseDto<List<EmployeeResponseDto>>> GetAllAsync(string Name)
        {
            if (Name == "" || Name == null)
            {
                var dbObject = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
                if (dbObject is null) return new ResponseDto<List<EmployeeResponseDto>>() { Status = 0, Data = null };
                var mappedObject = _mapper.Map<List<EmployeeResponseDto>>(dbObject);
                return new ResponseDto<List<EmployeeResponseDto>>() { Data = mappedObject };
            }
            else 
            {
                var dbObject = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true).ToListAsync();
                var Users = from Employee in dbObject
                            where Employee.User.FirstName.Contains(Name) || Employee.User.LastName.Contains(Name)|| (Employee.User.FirstName+" "+Employee.User.LastName).Contains(Name)
                            select Employee;
                var List = _mapper.Map<List<EmployeeResponseDto>>(Users);
                List = List.OrderByDescending(x => x.UserId).ToList();
                return new ResponseDto<List<EmployeeResponseDto>>() { Data = List };
            }
            
        }
        public async Task<List<EmployeeResponseDto>> GetAllAgents()
        {
            var DbList = await _db.Employees.Include(x => x.User).Where(x => x.User.IsActive == true && x.User.RoleId == 2).ToListAsync();
            var mappedObject = _mapper.Map<List<EmployeeResponseDto>>(DbList);
            return mappedObject;
        }
        public async Task<ResponseDto<UpdateEmployeeApiDto>> UpdateEmployeeApi(UpdateEmployeeApiDto model)
        {
            var dbObject = await _db.Employees.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (!(dbObject is null))
            {
                dbObject.User.Address = model.Address;
                dbObject.User.Email = model.Email;
                dbObject.User.Address = model.Address;
                dbObject.User.FirstName = model.FirstName;
                dbObject.User.LastName = model.LastName;
                dbObject.User.PhoneNumber = model.PhoneNumber;
                if (!string.IsNullOrEmpty(model.ProfileUrl)) dbObject.User.ProfileUrl = model.ProfileUrl;
                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var dbTech = _db.TechnicianDetails.Where(x => x.TechnichainId == model.UserId).FirstOrDefault();
            if (!(dbTech is null))
            {
                dbTech.Fees = model.Fees;
                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            else 
            {
                TechnicianDetails td = new TechnicianDetails();
                td.TechnichainId = model.UserId;
                td.Fees = model.Fees; 
                _db.TechnicianDetails.Add(td);
                _db.SaveChanges();
            }
            if (dbObject is null) return new ResponseDto<UpdateEmployeeApiDto>() { Status = 0, Data = model,Message="Something Went Wrong"};
            return new ResponseDto<UpdateEmployeeApiDto>() { Status=1,Data = model,Message="Successfully updated" };
        }
        public async Task<ResponseDto<UpdateEmployeeApiDto>> GetEmployeeApi(long UserId)
        {
            var dbObject = await _db.Employees.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == UserId);
            if (dbObject != null) 
            {
                var TechUser = _mapper.Map<UpdateEmployeeApiDto>(dbObject);
                var dbTech = _db.TechnicianDetails.Where(x => x.TechnichainId == UserId).FirstOrDefault();
                TechUser.Fees = 0;
                if (dbTech != null) 
                {
                    TechUser.Fees = dbTech.Fees;
                }
                return new ResponseDto<UpdateEmployeeApiDto>() { Status = 1, Data = TechUser};
            }
            return new ResponseDto<UpdateEmployeeApiDto>() { Status = 1, Data = null, Message = "No record Found" };
        }
        public ResponseDto<TechnicianLocationApiDto> UpdateTechnicianLocation(TechnicianLocationApiDto model)
        {
            var dbObject = _db.TechnicianDetails.Where(x => x.TechnichainId == model.TechnicianId).FirstOrDefault();
            if (dbObject != null)
            {
                dbObject.Latitude = model.Latitude;
                dbObject.Longitude = model.Longitude;
                _db.Entry(dbObject).State = EntityState.Modified;
                var result = _db.SaveChanges();
                if (result > 0)
                {
                    return new ResponseDto<TechnicianLocationApiDto>() { Status = 1, Data = model, Message = "Location Updated Successfully" };
                }
                else 
                {
                    return new ResponseDto<TechnicianLocationApiDto>() { Status = 0, Data = null, Message = "No record Found" };
                }
            }
            return new ResponseDto<TechnicianLocationApiDto>() { Status = 0, Data = null, Message = "No record Found" };
        }
    }
}