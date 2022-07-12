using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class CallRecordsViewModel
    {
        public CallRecordsViewModel() 
        {
            Records = new List<ManualCallRecordDto>();
        }
        public List<ManualCallRecordDto> Records { get; set; }
        public ManualCallRecordDto Record { get; set; }
    }
}
