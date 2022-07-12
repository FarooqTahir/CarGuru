using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using System.Collections.Generic;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ProductCategoryResponseDto:ProductCategoryBaseDto
    {
        public List<ProductSubCategoryRequestDto> ProductSubCategories { get; set; }
    }
}