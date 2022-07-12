using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ManualCallRecords
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string CarModel { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public string Description { get; set; }
    }
}
