using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class UserDeviceDto
    {
        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
        public string TimeZone { get; set; }
        public string ApplicationType { get; set; }
        //public long UserId { get; set; }
    }
}
