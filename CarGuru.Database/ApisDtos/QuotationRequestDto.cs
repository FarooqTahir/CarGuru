using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class QuotationRequestDto
    {
        public long CustomerId { get; set; }
        public long VehicleId { get; set; }
        public string ShippingAdress { get; set; }
        public string Description { get; set; }
        public string QutationType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<QuotationProduct> Services { get; set; }
    }
    public class QuotationProduct
    {
        public long ServiceId { get; set; }
    }
}
