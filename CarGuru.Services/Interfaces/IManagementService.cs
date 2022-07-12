using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IManagementService
    {
        public  Task<ResponseDto<ManagementDashboardSpResponseDto>> ManagementDashboardAnalytics(DateTime? startDate, DateTime? endDate);
        public Task<ResponseDto<TechnicianStatSpResponseDto>> TechnicianStatData(long? technicianId);
        public Task<ResponseDto<IEnumerable<CustomerProfileListSpResponseDto>>> CustomerProfileList();
        public Task<ResponseDto<List<RolesDto>>> GetEmployeeRoles();
        public Task<ResponseDto<ManagementReportSpResponseDto>> GetManagmentReports();
    }
}
