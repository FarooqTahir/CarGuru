using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class QuotationDto
    {
        public QuotationDto() 
        {
            Products = new List<ProductInQuotationDto>();
        }
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [Required]
        public long VehicleId { get; set; }
        public string ShippingAdress { get; set; }
        public string Description { get; set; }
        public string QutationType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal TotalPrice { get; set; }
        public string QuotationServices { get; set; }
        public List<ProductInQuotationDto> Products { get; set; }
    }
}
