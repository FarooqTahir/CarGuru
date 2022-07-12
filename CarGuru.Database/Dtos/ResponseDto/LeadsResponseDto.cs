using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class LeadsResponseDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LeadStatus { get; set; }
        public string CustomerAddress { get; set; }

    }
}
