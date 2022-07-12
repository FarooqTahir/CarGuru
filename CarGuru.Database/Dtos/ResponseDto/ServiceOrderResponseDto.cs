using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ServiceOrderResponseDto
    {
        public long Id { get; set; }
        public long? AgentId { get; set; }
        public long? SourceId { get; set; }
        public long? AssignedToId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ServiceOrderNo { get; set; }
        public decimal? Margin { get; set; }
        public decimal? ServiceCharges { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string AlternateAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
    }
}
