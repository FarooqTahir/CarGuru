using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class QuotationRequestListSpResponseDto
    {
        public int CustomerUserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string QutationType { get; set; }
        public string BillingAddress { get; set; }
        public double TotalPrice { get; set; }
        public bool IsCompleted { get; set; }
        public int QuotationId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string year { get; set; }
        public string CreatedDate { get; set; }
    }
}
