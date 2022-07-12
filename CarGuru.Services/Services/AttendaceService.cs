using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class AttendaceService:IAttendanceService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AttendaceService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<AttendanceAPiDto>> CheckIn(long Id)
        {
            var date = DateTime.UtcNow;
            var dbUser = _db.Attendance.Where(x => x.Date.Date == date.Date && x.CheckOut == null && x.UserId==Id).FirstOrDefault();
            if (!(dbUser == null))
            {
                var mappedResponse = _mapper.Map<Attendance, AttendanceAPiDto>(dbUser);
                return new ResponseDto<AttendanceAPiDto>() { Data = mappedResponse, Message = "Already Checked In" };
            }
            else 
            {
                var attendance = new AttendanceAPiDto();
                attendance.CheckIn = DateTime.UtcNow;
                attendance.CheckOut = null;
                attendance.Date = DateTime.UtcNow;
                attendance.UserId = Id;
                var mappedObject = _mapper.Map<AttendanceAPiDto, Attendance>(attendance);
                _db.Attendance.Add(mappedObject);
                await _db.SaveChangesAsync();
                var mappedResponse = _mapper.Map<Attendance, AttendanceAPiDto>(mappedObject);
                return new ResponseDto<AttendanceAPiDto>() { Data = mappedResponse ,Message="Checked In Successfully"};
            }
        }
        public async Task<ResponseDto<AttendanceAPiDto>> CheckOut(long Id)
        {
            DateTime date = DateTime.UtcNow.Date;
            var dbUser = _db.Attendance.Where(x => x.Date.Date == date.Date && x.CheckOut == null && x.UserId==Id).FirstOrDefault();
            if (!(dbUser == null))
            {
                dbUser.CheckOut = DateTime.UtcNow;
                dbUser.UserId = Id;
                _db.Entry(dbUser).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                var mappedResponse = _mapper.Map<Attendance, AttendanceAPiDto>(dbUser);
                return new ResponseDto<AttendanceAPiDto>() { Data = mappedResponse, Message = "Checkout Successfully" };
            }
            else
            {
                return new ResponseDto<AttendanceAPiDto>() { Data = null, Message = "Please CheckIn First" };
            }
        }
    }
}
