using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ProductSubCategoryRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Sub Category is Required.")]
        public string Title { get; set; }
    }
}
