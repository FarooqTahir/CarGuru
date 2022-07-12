using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.Models
{
    public class QuotationViewModel
    {
        public QuotationViewModel()
        {
            Products = new List<SelectListItem>();
        }
        public ResponseDto<List<QuotationRequestListSpResponseDto>> QuotationRequests { get; set; }
        public List<SelectListItem> Products { get; set; }
        public ResponseDto<QuotationDetailSpResponseDto> QuotationDetail { get; set; }
        public bool IsView { get; set; } = true;
    }
}
