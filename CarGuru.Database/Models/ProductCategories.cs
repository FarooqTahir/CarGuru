using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductCategories
    {
        public ProductCategories()
        {
            ProductSubCategories = new HashSet<ProductSubCategories>();
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ProductSubCategories> ProductSubCategories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
