using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ServiceOrdersListSpResponseDto
    {
        public string Agent { get; set; }
        public string OrderStatus { get; set; }
        public string Customer { get; set; }
        public string Source { get; set; }
        public string Technician { get; set; }
        public int Id { get; set; }
        public int? AgentId { get; set; }
        public int SourceId { get; set; }
        public int? AssignedToId { get; set; }
        public int OrderStatusId { get; set; }
        public long ServiceOrderNo { get; set; }
        public decimal Margin { get; set; }
        public double ServiceCharges { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string AlternateAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public long CustomerId { get; set; }
        public int ServiceTypeId { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<ServiceType> ServiceTypes { get; set; }
        public List<Product> Products { get; set; }
    }
}
