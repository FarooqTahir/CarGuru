using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class InvoiceRequestApiDto
    {
        public long CustomerId { get; set; }
        public long ServiceOrderId { get; set; }
    }
}
