using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ServicesInServiceOrderDto
    {
        public int ServiceTypeId { get; set; }
        public long ServiceOrderId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
