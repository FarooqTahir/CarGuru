using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class APILogs
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string FunctionRequest { get; set; }
        public string FunctionResponse { get; set; }
        public string IPAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
