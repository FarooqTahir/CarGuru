using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class GetAllProductsListFilter
    {
        public List<ProductListDto> Products { get; set; }
        public List<ProductSubCategoryRequestDto> SubCategoryList { get; set; }

    }
}
