using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Products
    {
        public Products()
        {
            ProductsInQoutations = new HashSet<ProductsInQoutations>();
            ProductsInServiceOrders = new HashSet<ProductsInServiceOrders>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal RegularPrice { get; set; }
        public int StockStatus { get; set; }
        public string SkuNo { get; set; }
        public long VendorId { get; set; }
        public string ProductDiscount { get; set; }
        public decimal? LeastPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public bool? IsActive { get; set; }
        public long? FleetId { get; set; }
        public int? DeadStock { get; set; }
        public string QrCode { get; set; }
        public string Manufacturer { get; set; }

        public virtual ProductCategories ProductCategory { get; set; }
        public virtual Vendors Vendor { get; set; }
        public virtual ICollection<ProductsInQoutations> ProductsInQoutations { get; set; }
        public virtual ICollection<ProductsInServiceOrders> ProductsInServiceOrders { get; set; }
    }
}
