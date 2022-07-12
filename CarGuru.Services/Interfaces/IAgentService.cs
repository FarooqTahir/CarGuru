using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IAgentService
    {
        public Task<ResponseDto<AgentDashboardSpResponseDto>> AgentDashboardAnalytics(long? agentId, DateTime? startDate, DateTime? endDate);
    }
}
