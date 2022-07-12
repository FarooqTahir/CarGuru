using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ServiceOrders
    {
        public long Id { get; set; }
        public long? AgentId { get; set; }
        public long? SourceId { get; set; }
        public long? AssignedToId { get; set; }
        public int? OrderStatusId { get; set; }
        public long? CustomerId { get; set; }
        public long? VehicleId { get; set; }
        public string ServiceOrderNo { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ScheduleDateTime { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? RatingByTechnician { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
