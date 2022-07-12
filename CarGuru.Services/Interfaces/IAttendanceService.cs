using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<ResponseDto<AttendanceAPiDto>> CheckIn(long Id);
        Task<ResponseDto<AttendanceAPiDto>> CheckOut(long Id);
    }
}
