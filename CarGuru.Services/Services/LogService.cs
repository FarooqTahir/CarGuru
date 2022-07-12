using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class LogService : ILogService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public LogService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public long AddAPILogs(APILogDto model)
        {
            var log = _mapper.Map<APILogDto, APILogs>(model);
            _db.APILogs.Add(log);
         _db.SaveChanges();
            return log.Id;
        }
        public bool UpdateAPILogs(long logId,string response)
        {
            var log = _db.APILogs.FirstOrDefault(a => a.Id == logId);
            if (!(log is null))
            {
                log.FunctionResponse = response;
                _db.Entry(log).State = EntityState.Modified;
               _db.SaveChanges();
            }
            return true;

        }
    }
}
