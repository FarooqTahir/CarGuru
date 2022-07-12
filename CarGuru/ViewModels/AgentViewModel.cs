using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class AgentViewModel
    {
        public AgentViewModel() 
        {
            Leads = new List<LeadsResponseDto>();
        }
        public List<LeadsResponseDto> Leads { get; set; }
        
    }
}
