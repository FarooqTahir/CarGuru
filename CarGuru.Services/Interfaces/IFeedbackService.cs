using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<ResponseDto<FeedbackRequestDto>> CreateAsync(FeedbackRequestDto model);
        Task<ResponseDto<List<FeedBackListDto>>> TechnicianFeedbak(long Id);
    }
}
