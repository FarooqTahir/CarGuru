using System;
using System.ComponentModel.DataAnnotations;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class ProductBaseDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        public decimal? SalePrice { get; set; }
        //[Required(ErrorMessage = "Product Cost is Required")]
        public decimal? RegularPrice { get; set; }
        //[Required]
        public int? StockStatus { get; set; }
        //[Required]
        public long? VendorId { get; set; }
        public string ProductMargin { get; set; }
        //[Required]
        public string SkuNo { get; set; }
        public decimal? LeastPrice { get; set; }
        //[Required]
        public int ProductCategoryId { get; set; }
        //[Required]
        public int ProductSubCategoryId { get; set; }
        //[Required]
        public string Manufacturer { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public long? FleetId { get; set; }
        //[Required]
        public int? DeadStock { get; set; }
        //[Required(ErrorMessage = "Bar Code is Required")]
        public string QrCode { get; set; }
    }
}