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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class ManagementService : IManagementService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ManagementService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<ManagementDashboardSpResponseDto>> ManagementDashboardAnalytics(DateTime? startDate, DateTime? endDate)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spManagementDashboardStatistics]", param: new { StartDate = startDate, EndDate = endDate },
                   commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<ManagementDashboardSpResponseDto>(builder.ToString());
                if (!(result is null))
                {
                    return new ResponseDto<ManagementDashboardSpResponseDto>()
                    {
                        Data = response
                    };
                }
                return new ResponseDto<ManagementDashboardSpResponseDto>();
            }
        }
        public async Task<ResponseDto<TechnicianStatSpResponseDto>> TechnicianStatData(long? technicianId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spTechnicianStatistics]", param: new { TechnicianId = technicianId },
                   commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<TechnicianStatSpResponseDto>(builder.ToString());
                if (!(result is null))
                {
                    return new ResponseDto<TechnicianStatSpResponseDto>()
                    {
                        Data = response
                    };
                }
                return new ResponseDto<TechnicianStatSpResponseDto>();
            }
        }
        public async Task<ResponseDto<IEnumerable<CustomerProfileListSpResponseDto>>> CustomerProfileList()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<CustomerProfileListSpResponseDto>(sql: "[dbo].[spGetCustomerProfileList]", null,
                   commandType: CommandType.StoredProcedure);
                if (!(result is null))
                {
                    result = result.ToList();
                    return new ResponseDto<IEnumerable<CustomerProfileListSpResponseDto>>()
                    {
                        Data = result
                    };
                }
                return new ResponseDto<IEnumerable<CustomerProfileListSpResponseDto>>();
            }
        }
        public async Task<ResponseDto<List<RolesDto>>> GetEmployeeRoles()
        {
            var roles = await _db.Roles.Where(a => a.Id != 1 && a.Id != 4).ToListAsync();
            var RolesData = _mapper.Map<List<Roles>,List<RolesDto>>(roles);
            return new ResponseDto<List<RolesDto>>()
            {
                Data = RolesData
            };
        }
        public async Task<ResponseDto<ManagementReportSpResponseDto>> GetManagmentReports()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetManagementRecord]",null,
                   commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<ManagementReportSpResponseDto>(builder.ToString());
                if (!(result is null))
                {
                    return new ResponseDto<ManagementReportSpResponseDto>()
                    {
                        Data = response
                    };
                }
                return new ResponseDto<ManagementReportSpResponseDto>();
            }
        }
    }
}
