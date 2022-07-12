using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class SupervisorViewModel
    {
        public SupervisorViewModel()
        {
            Agents = new List<EmployeeResponseDto>();
            Orders = new List<ServiceOrdersListSpResponseDto>();
            Leads = new List<LeadsResponseDto>();
        }
        public List<EmployeeResponseDto> Agents { get; set; }
        public EmployeeRequestDto Agent { get; set; }
        public List<ServiceOrdersListSpResponseDto> Orders { get; set; }
        public string AgentName { get; set; }
        public List<LeadsResponseDto> Leads { get; set; }

    }
}
