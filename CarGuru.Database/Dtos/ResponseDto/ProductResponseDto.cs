using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using System.Collections.Generic;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ProductResponseDto:ProductBaseDto
    {
        public  VendorResponseDto Vendor { get; set; }
        public  List<ProductSubCategoryRequestDto> SubCategories { get; set; }
    }
}