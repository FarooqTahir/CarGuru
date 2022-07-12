using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class InvoiceResponseDto
    {
       public ServiceOrderRequestDto Data { get; set; }
       public Decimal ProductCost { get; set; }
       public Decimal ServiceCharges { get; set; }
       public Decimal Total { get; set; }
    }
}
