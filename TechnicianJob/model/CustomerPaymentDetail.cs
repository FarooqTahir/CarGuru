using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class CustomerPaymentDetail
    {
        public long Id { get; set; }
        public long CardDetailId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
        public string ChargeId { get; set; }
    }
}
