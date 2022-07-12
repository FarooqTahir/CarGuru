using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductsInServiceOrderes
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long ServiceOrderId { get; set; }
    }
}
