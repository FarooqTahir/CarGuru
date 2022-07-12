using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class ProductListDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        [Required]
        public decimal RegularPrice { get; set; }
        [Required]
        public int StockStatus { get; set; }
        [Required]
        public long VendorId { get; set; }
        [Required]
        public string ProductMargin { get; set; }
        [Required]
        public string SkuNo { get; set; }
        public decimal? LeastPrice { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        [Required]
        public long? FleetId { get; set; }
        [Required]
        public int? DeadStock { get; set; }
        [Required]
        public string QrCode { get; set; }
        public ProductCategoryBaseDto ProductCategory { get; set; }
        public ProductSubCategoryRequestDto ProductSubCategory { get; set; }
        public VendorDto Vendor { get; set; }

    }
}
