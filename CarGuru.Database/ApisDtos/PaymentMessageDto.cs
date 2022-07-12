using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class PaymentMessageDto
    {
        public long OrderId { get; set; }
        public decimal InvoiceTotal { get; set; }
        public long CustomerId { get; set; }
    }
}
