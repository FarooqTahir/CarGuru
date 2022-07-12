using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicianJob.Dtos
{
    public class AssignOrderDto
    {
        public List<Order> Orders { get; set; }
        public List<AvailableTechnician> AvailableTechnicians { get; set; }
    }
    public class Order
    {
        public string Customer { get; set; }
        public int CustomerUserId { get; set; }
        public string OrderStatus { get; set; }
        public int Id { get; set; }
        public object AgentId { get; set; }
        public int SourceId { get; set; }
        public object AssignedToId { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public string ServiceOrderNo { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object RatingByTechnician { get; set; }
        public object ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public object UpdatedDate { get; set; }
        public object UpdateById { get; set; }
    }

    public class AvailableTechnician
    {
        public int TechnicianUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int total { get; set; }
    }

}
