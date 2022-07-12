using CarGuru.Database.Dtos.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ServiceOrderRequestDto : ServiceOrderBaseDto
    {
        public ServiceOrderRequestDto()
        {
            Products = new List<ProductInServiceOrderDto>();
            Services = new List<ServicesInServiceOrderDto>();
        }
        public List<ProductInServiceOrderDto> Products { get; set; }
        public List<ServicesInServiceOrderDto> Services { get; set; }
        public TimeSpan SchaduledTime { get; set; }
    }
}
