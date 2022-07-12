using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Qoutations
    {
        public Qoutations()
        {
            ProductsInQoutations = new HashSet<ProductsInQoutations>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string ShippingAdress { get; set; }
        public string QutationType { get; set; }
        public string Description { get; set; }
        public long? VehicleId { get; set; }
        public decimal? Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsCompleted { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<ProductsInQoutations> ProductsInQoutations { get; set; }
    }
}
