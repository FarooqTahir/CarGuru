using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class UserProfileService:IUserProfileService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UserProfileService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public UserUpdateDto UpdateProfile(UserUpdateDto model) 
        {
            var User = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
            if (User != null) 
            {
                User.Password = model.Password;
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.ProfileUrl = model.ProfileUrl;
                User.Email = model.Email;
                User.Password = model.Password;
                User.PhoneNumber = model.PhoneNumber;
                User.GenderId = model.GenderId;
                User.Address = model.Address;

                _db.Entry(User).State = EntityState.Modified;
                _db.SaveChanges();
            
            }
            return model;
        }
        public async Task<UserUpdateDto> GetByUserId(long Id)
        {
            var User = await _db.Users.Where(x => x.UserId == Id).FirstOrDefaultAsync();
            UserUpdateDto model = new UserUpdateDto();
            if (User != null)
            {
                model = _mapper.Map<Users, UserUpdateDto>(User);
                return model;
            }
            return model;

        }

        public async Task<UserUpdateModelDto> UpdateProfileAsync(UserUpdateModelDto model)
        {
            var User = await _db.Users.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (User != null)
            {
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.ProfileUrl = model.ProfileUrl;
                User.Email = model.Email;
                User.PhoneNumber = model.PhoneNumber;
                User.GenderId = model.GenderId;
                User.Address = model.Address;

                _db.Entry(User).State = EntityState.Modified;
                _db.SaveChanges();

            }
            return model;
        }

        public async Task<UserUpdateModelDto> GetByUserIdAsync(long Id)
        {
            var User = await _db.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            UserUpdateModelDto model = new UserUpdateModelDto();
            if (User != null)
            {
                model = _mapper.Map<Users, UserUpdateModelDto>(User);
                return model;
            }
            return model;
        }
    }
}
