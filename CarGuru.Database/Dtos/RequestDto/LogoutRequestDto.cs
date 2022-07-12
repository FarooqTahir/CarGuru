using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class LogoutRequestDto
    {
        public long UserId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
    }
}
