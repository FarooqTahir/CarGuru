using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class ServicesInOrder
    {
        public int ServiceTypeId { get; set; }
        public long ServiceOrderId { get; set; }
        public decimal Price { get; set; }
    }
}
