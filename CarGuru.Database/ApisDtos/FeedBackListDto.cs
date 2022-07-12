using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class FeedBackListDto
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public long ServiceOrderNo { get; set; }
        public string Customer { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
