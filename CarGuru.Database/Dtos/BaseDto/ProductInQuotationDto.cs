using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class ProductInQuotationDto
    {
        public long? QoutationId { get; set; }
        public long? ProductId { get; set; }
        public long? ServiceId { get; set; }
        public decimal Price { get; set; }
    }
}
