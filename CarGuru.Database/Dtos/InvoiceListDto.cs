using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class InvoiceListDto
    {
        public long Id { get; set; }
        public string Agent { get; set; }
        public string Source { get; set; }
        public string Technician { get; set; }
        public object ServiceOrderNo { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public object VehicleModel { get; set; }
        public object VehicleMake { get; set; }
        public object VehicleYear { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public long OrderStatusId { get; set; }
        public string InvoiceStatus { get; set; }
    }
}
