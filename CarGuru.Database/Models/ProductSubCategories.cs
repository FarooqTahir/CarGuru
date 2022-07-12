using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductSubCategories
    {
        public ProductSubCategories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public bool? IsActive { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual ProductCategories ProductCategory { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
