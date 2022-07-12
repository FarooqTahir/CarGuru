using CarGuru.Database.Dtos.BaseDto;
using System.Collections.Generic;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ProductCategoryRequestDto:ProductCategoryBaseDto
    {
        public ProductCategoryRequestDto()
        {
            ProductSubCategories = new List<ProductSubCategoryRequestDto>();
        }
        public List<ProductSubCategoryRequestDto> ProductSubCategories { get; set; }
    }
}