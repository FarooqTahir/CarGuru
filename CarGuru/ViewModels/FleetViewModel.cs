using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class FleetViewModel
    {
        public FleetViewModel()
        {
            FleetList = new List<FleetResponseDto>();
        }
        public FleetRequestDto Fleet { get; set; }
        public List<FleetResponseDto> FleetList { get; set; }
    }
}
