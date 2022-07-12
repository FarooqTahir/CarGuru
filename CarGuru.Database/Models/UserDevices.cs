using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class UserDevices
    {
        public long UserId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }

        public virtual Users User { get; set; }
    }
}
