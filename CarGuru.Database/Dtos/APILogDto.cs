using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class APILogDto
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
