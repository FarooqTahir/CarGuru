using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class TechnicianDetails
    {
        public long Id { get; set; }
        public decimal Fees { get; set; }
        public long TechnichainId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
