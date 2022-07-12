using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ProductInServiceOrderDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long ServiceOrderId { get; set; }
    }
}
