using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Feedback
    {
        public long Id { get; set; }
        public long TechnicianId { get; set; }
        public long CustomerId { get; set; }
        public long OrderId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
