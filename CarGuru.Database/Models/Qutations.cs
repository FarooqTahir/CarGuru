using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Qutations
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string ShippingAdress { get; set; }
        public string QutationType { get; set; }
        public decimal? Margin { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
    }
}
