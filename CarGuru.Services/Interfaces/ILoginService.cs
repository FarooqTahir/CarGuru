using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;

namespace CarGuru.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto model);
        ResponseDto<List<Roles>> UserRoles();
        ResponseDto<UserResponseDto> SignUp(UserSignupDto model);
        bool ForgotPassword(string email);
        bool AddRequest(MakeRequestApiDto model);
        public Task<ResponseDto<LoginResponseDto>> MLoginAsync(UserDeviceDto model);
        public Task<ResponseDto<bool>> Logout(LogoutRequestDto request);
    }
}