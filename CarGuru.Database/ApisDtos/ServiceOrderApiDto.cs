using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class ServiceOrderApiDto
    {
        public List<MServices> Services { get; set; }
        public long CustomerId { get; set; }
        public long VehicleId { get; set; }
        public string ShippingAdress { get; set; }
        public DateTime SchaduleDateTime { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
    public class MServices 
    {
        public int ServiceTypeId { get; set; }
    }
}
