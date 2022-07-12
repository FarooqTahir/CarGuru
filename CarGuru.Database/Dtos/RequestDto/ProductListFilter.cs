using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ProductListFilter
    {
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
