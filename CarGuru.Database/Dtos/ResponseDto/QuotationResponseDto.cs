using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class QuotationResponseDto
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? VehicleId { get; set; }
        public string ShippingAdress { get; set; }
        public string QutationType { get; set; }
        public decimal? Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
    }
}
