using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class Notifications
    {
        public long Id { get; set; }
        public long NotificationTo { get; set; }
        public long NotificationFrom { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
    }
}
