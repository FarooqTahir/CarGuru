using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class QuotationListApiDto
    {
        public int QuotationId { get; set; }
        public int CustomerUserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string CustomerName { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Mulkia { get; set; }
        public string VIn { get; set; }
        public string Year { get; set; }
        public string CustomerType { get; set; }
    }
}
