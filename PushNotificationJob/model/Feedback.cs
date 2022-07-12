using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class Feedback
    {
        public long Id { get; set; }
        public long TechnicianId { get; set; }
        public long CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
