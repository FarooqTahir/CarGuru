using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Notifications
    {
        public long Id { get; set; }
        public long NotificationTo { get; set; }
        public long NotificationFrom { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
        public int? TypeId { get; set; }

        public virtual Lookups Type { get; set; }
    }
}
