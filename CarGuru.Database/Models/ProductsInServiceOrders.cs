using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductsInServiceOrders
    {
        public long ProductId { get; set; }
        public long ServiceOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductMargin { get; set; }

        public virtual Products Product { get; set; }
    }
}
