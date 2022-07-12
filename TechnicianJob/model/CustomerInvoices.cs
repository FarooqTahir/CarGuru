using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class CustomerInvoices
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? CustomerVehicleId { get; set; }
        public long? ServiceOrderId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
