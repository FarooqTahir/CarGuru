using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ServicesInOrder
    {
        public int ServiceTypeId { get; set; }
        public long ServiceOrderId { get; set; }
        public decimal Price { get; set; }
    }
}
