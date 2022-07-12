using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class ProductInOrderApiDto
    {
        public long ProductId { get; set; }
        public long ServiceOrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductMargin { get; set; }

    }
}
