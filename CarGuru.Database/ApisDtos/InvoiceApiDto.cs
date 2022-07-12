using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Service
    {
        public string ServiceName { get; set; }
        public Decimal Price { get; set; }

    }

    public class Product
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductMargin { get; set; }

    }

    public class InvoiceApiDto
    {
        InvoiceApiDto() 
        {
            Services = new List<Service>();
            Products = new List<Product>();
        }
        public int ServiceOrderId { get; set; }
        public string Agent { get; set; }
        public string Source { get; set; }
        public string Technician { get; set; }
        public string ServiceOrderNo { get; set; }
        public string TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Mulkia { get; set; }
        public string VehicleYear { get; set; }
        public long CustomerId { get; set; }
        public long? TechnicianId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }

    }



}
