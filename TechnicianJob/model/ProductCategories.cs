using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class ProductCategories
    {
        public ProductCategories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
