using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;

namespace CarGuru.Services.Interfaces
{
   public interface IUserService
   {
       Task<ResponseDto<List<UserResponseDto>>> GetAllAsync();

       Task<ResponseDto<UserResponseDto>> AddUserAsync(UserRequestDto userRequest);
       ResponseDto<List<UserResponseDto>> UsersListByRoleId(int Role);
       ResponseDto<List<UserResponseDto>> UsersChatListByRoleId(int Role);
        public ResponseDto<CustomerResponseDto> CustomerByUserId(long Id);
        public Task<ResponseDto<List<UserDevicesDto>>> GetUserDevices(long userId);
    }
}
