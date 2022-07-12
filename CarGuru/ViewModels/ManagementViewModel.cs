using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class ManagementViewModel
    {
        public ManagementViewModel()
        {
            Vendors = new List<VendorResponseDto>();
            TechnicianList = new List<SelectListItem>();
        }
        public VendorRequestDto Vendor { get; set; }
        public List<VendorResponseDto> Vendors { get; set; }
        public ResponseDto<ManagementDashboardSpResponseDto> ManagementStat {get;set;}
        public ResponseDto<ManagementReportSpResponseDto> ReportStat {get;set; }
        public ResponseDto<TechnicianStatSpResponseDto> TechnicianStat {get;set; }
        public List<SelectListItem> TechnicianList { get; set; }
    }
}
