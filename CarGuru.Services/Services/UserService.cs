using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarGuru.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ISessionManager _sessionManager;

        public UserService( ApplicationDbContext dbContext, IMapper mapper,ISessionManager sessionManager
        )
        {
            _db = dbContext;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<ResponseDto<List<UserResponseDto>>> GetAllAsync()
        {
            var users = await _db.Users.ToListAsync();
            var userDtoList = _mapper.Map<List<Users>, List<UserResponseDto>>(users);
            var response = new ResponseDto<List<UserResponseDto>> { Data = userDtoList };
            return response;
        }
        public async Task<ResponseDto<UserResponseDto>> AddUserAsync(UserRequestDto userRequest)
        {
            var mappedObject = _mapper.Map<UserRequestDto, Users>(userRequest);
            _db.Users.Add(mappedObject);
            await _db.SaveChangesAsync();
            var mappedResponse = _mapper.Map<Users, UserResponseDto>(mappedObject);
            return new ResponseDto<UserResponseDto>(){Data = mappedResponse};
        }
        public ResponseDto<List<UserResponseDto>> UsersListByRoleId(int Role)
        {
            if (Role == 0)
            {
                var Users = _db.Users.Where(x => x.RoleId == 2|| x.RoleId == 3|| x.RoleId == 5 && x.IsActive==true).ToList();
                var userDtoList = _mapper.Map<List<Users>, List<UserResponseDto>>(Users);
                return new ResponseDto<List<UserResponseDto>>() { Data = userDtoList };
            }
            else 
            {
                var Users = _db.Users.Where(x=>x.RoleId == Role && x.IsActive == true).ToList();
                var userDtoList = _mapper.Map<List<Users>, List<UserResponseDto>>(Users);
                return new ResponseDto<List<UserResponseDto>>() { Data = userDtoList };
            }
            
        }
        public ResponseDto<List<UserResponseDto>> UsersChatListByRoleId(int Role)
        {
            long LogedInUser = _sessionManager.GetUserId();
            var Users = _db.Users.Where(x => x.RoleId == Role && x.UserId != LogedInUser && x.IsActive == true).ToList();
            var userDtoList = _mapper.Map<List<Users>, List<UserResponseDto>>(Users);
            return new ResponseDto<List<UserResponseDto>>() { Data = userDtoList };
        }
        public ResponseDto<CustomerResponseDto> CustomerByUserId(long Id) 
        {
            var Users = _db.Users.Where(x => x.UserId==Id).FirstOrDefault();
            var userDto = _mapper.Map<Users, UserResponseDto>(Users);

            var Customer = _db.Customers.Where(x => x.UserId == Id).FirstOrDefault();
            var CustomerDto = _mapper.Map<Customers, CustomerResponseDto>(Customer);

            CustomerDto.User = userDto;

            return new ResponseDto<CustomerResponseDto>() { Data = CustomerDto };
        }
        public async Task<ResponseDto<List<UserDevicesDto>>> GetUserDevices(long userId)
        {
            var UserDevices = await _db.UserDevices.Where(x => x.UserId == userId).ToListAsync();
            var Devices = _mapper.Map<List<UserDevices>,List<UserDevicesDto>>(UserDevices);
            return new ResponseDto<List<UserDevicesDto>>() { Data = Devices };
        }
    }
}
