using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class Employees
    {
        public long Id { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
