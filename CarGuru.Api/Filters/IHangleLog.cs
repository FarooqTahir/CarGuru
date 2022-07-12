using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.Api.Filters
{
    public interface IHangleLog
    {
        public bool Write(long logId, string response);
        public long Add(ActionExecutingContext context);
    }
}
