using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IQuotationService
    {
        public Task<ResponseDto<QuotationResponseDto>> AddQuotationRequest(QuotationRequestDto model);
        Task<ResponseDto<List<QuotationRequestListSpResponseDto>>> GetQuotationRequestList(string Name);
        public Task<ResponseDto<QuotationDetailSpResponseDto>> GetQuotationDetailByQuotationId(long quotationId);
        Task<ResponseDto<UpdateQuotationResponseDto>> UpdateQuotationProduct(long quotationId, long quotationDetailId = 0, long productId = 0);
        ResponseDto<QuotationResponseDto> AddQuotationRequestW(QuotationDto model);
        bool AddDescription(string description, long QuotationId);
        Task<ResponseDto<List<QuotationRequestListSpResponseDto>>> GetQuotationRequestListByCustomerId(long UserId);
        Task<ResponseDto<List<QuotationListApiDto>>> QuotationsListM();
    }
}
