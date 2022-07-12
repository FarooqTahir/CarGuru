using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AgentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<AgentDashboardSpResponseDto>> AgentDashboardAnalytics(long? agentId,DateTime? startDate,DateTime? endDate)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                await conn.OpenAsync();
                long aId = 0;
                if (agentId.HasValue) aId = agentId.Value;
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spAgentDashboardStatistics]", param: new { AgentId = agentId, StartDate = startDate,EndDate = endDate },
                   commandTimeout: 60,commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                await conn.CloseAsync();
                var response = JsonConvert.DeserializeObject<AgentDashboardSpResponseDto>(builder.ToString());
                if (!(result is null))
                {
                    return new ResponseDto<AgentDashboardSpResponseDto>()
                    {
                        Data = response
                    };
                }
                return new ResponseDto<AgentDashboardSpResponseDto>();
            }
        }
    }
}
