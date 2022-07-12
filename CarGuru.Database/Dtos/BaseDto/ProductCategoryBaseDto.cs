using System;
using System.ComponentModel.DataAnnotations;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class ProductCategoryBaseDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
    }
}