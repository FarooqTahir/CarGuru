using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductsInQoutation
    {
        public long Id { get; set; }
        public long QoutationId { get; set; }
        public long ProductId { get; set; }
        public long ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
