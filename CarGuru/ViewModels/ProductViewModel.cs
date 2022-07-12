using System.Collections.Generic;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<SelectListItem>();
            ProductSubCategories = new List<SelectListItem>();
            Vendors = new List<SelectListItem>();
            Fleets = new List<SelectListItem>();
            Products = new List<ProductResponseDto>();
            Categories = new List<ProductCategoryResponseDto>();
            Category = new ProductCategoryRequestDto(); 
        }
        public List<SelectListItem> ProductCategories { get; set; }
        public List<SelectListItem> ProductSubCategories { get; set; }
        public List<SelectListItem> Vendors { get; set; }
        public List<SelectListItem> Fleets { get; set; }

        public ProductRequestDto ProductRequestDto { get; set; }
        public ProductRequestDto ProductEditRequestDto { get; set; }

        public List<ProductResponseDto> Products { get; set; }
        public List<ProductCategoryResponseDto> Categories { get; set; }
        public ProductCategoryRequestDto Category { get; set; }

    }
}