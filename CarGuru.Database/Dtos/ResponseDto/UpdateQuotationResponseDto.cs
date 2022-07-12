using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
   public class UpdateQuotationResponseDto
    {
        public decimal SalePrice { get; set; }
        public double Margin { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
    }
}
