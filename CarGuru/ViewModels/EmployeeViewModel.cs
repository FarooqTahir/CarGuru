using System.Collections.Generic;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            EmployeeTypes = new List<SelectListItem>();
            EmployeesList = new List<EmployeeResponseDto>();
        }

        public List<SelectListItem> EmployeeTypes { get; set; }

        public EmployeeRequestDto EmployeeRequestDto { get; set; }

        public List<EmployeeResponseDto> EmployeesList { get; set; }
    }
}