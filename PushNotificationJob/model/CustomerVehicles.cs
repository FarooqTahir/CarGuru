using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class CustomerVehicles
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public bool? IsActive { get; set; }
        public string Mulkia { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
