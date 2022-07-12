using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class TechDashbordApiDto
    {
        TechDashbordApiDto() 
        {
            ServiceData = new List<ServiceData>();
        }
        public double? Earnings { get; set; }
        public int? Jobs { get; set; }
        public List<ServiceData> ServiceData { get; set; }
    }
    public class ServiceData
    {
        public int ServiceOrderId { get; set; }
        public string Agent { get; set; }
        public string Source { get; set; }
        public string OrderStatus { get; set; }
        public string Technician { get; set; }
        public object ServiceOrderNo { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleYear { get; set; }

    }


}
