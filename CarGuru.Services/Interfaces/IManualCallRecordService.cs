using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IManualCallRecordService
    {
        Task<ResponseDto<ManualCallRecordDto>> Create(ManualCallRecordDto model);
        Task<ResponseDto<List<ManualCallRecordDto>>> List(string name);
        Task<ResponseDto<List<ManualCallRecordDto>>> CreateAsync(ManualCallRecordDto model);
        Task<ResponseDto<List<ManualCallRecordDto>>> UpdateAsync(ManualCallRecordDto model);
        Task<ResponseDto<List<ManualCallRecordDto>>> DeleteRecord(long Id);
        Task<ResponseDto<ManualCallRecordDto>> GetByIdAsync(long Id);
    }
}
