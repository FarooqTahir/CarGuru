using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class NotificationQueue
    {
        public long Id { get; set; }
        public bool IsSent { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
