using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class ServiceOrderBaseDto
    {
        public long Id { get; set; } = 0;
        [Required]
        public long? AgentId { get; set; }
        [Required]
        public long? SourceId { get; set; }
        public long CustomerId { get; set; }
        [Required]
        public long? AssignedToId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ServiceOrderNo { get; set; }
        public decimal? Margin { get; set; }
        public decimal? ServiceCharges { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ReceivedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime ScheduleDateTime { get; set; } = DateTime.UtcNow;
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string AlternateAddress { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public int? ServiceTypeId { get; set; }
        [Required]
        public int? VehicleId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
