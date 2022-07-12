using CarGuru.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface ILogService
    {
        public long AddAPILogs(APILogDto model);
        public bool UpdateAPILogs(long logId, string response);
    }
}
