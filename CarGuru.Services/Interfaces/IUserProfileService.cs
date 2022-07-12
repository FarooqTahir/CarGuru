using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IUserProfileService
    {
        UserUpdateDto UpdateProfile(UserUpdateDto model);
        Task<UserUpdateModelDto> UpdateProfileAsync(UserUpdateModelDto model);
        Task<UserUpdateDto> GetByUserId(long Id);
        Task<UserUpdateModelDto> GetByUserIdAsync(long Id);
    }
}
