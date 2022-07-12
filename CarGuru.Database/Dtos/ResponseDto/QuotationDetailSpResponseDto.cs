using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class QuotationProducts
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        //public double Price { get; set; }
        public string Service { get; set; }
        public string ProductDiscount { get; set; }
        public double? ProductPrice { get; set; }

    }

    public class QuotationDetailSpResponseDto
    {
        public long QuotationId { get; set; }
        public long CustomerUserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public object BillingAddress { get; set; }
        public string ShippingAdress { get; set; }
        public string QutationType { get; set; }
        public object Discount { get; set; }
        public string Description { get; set; }
        public string VehicleNumber { get; set; }
        public List<QuotationProducts> QuotationProducts { get; set; }

    }
}
