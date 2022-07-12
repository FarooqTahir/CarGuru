using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class PushQueueDto
    {
        public bool IsSent { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
