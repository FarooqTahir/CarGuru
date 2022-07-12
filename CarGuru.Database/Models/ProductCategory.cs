using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
    }
}
