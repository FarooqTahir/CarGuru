using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class UserSignupDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerTypeId { get; set; }
        public int RoleId { get; set; }
        public int DeviceTypeId { get; set; }
        public decimal? Fees { get; set; }
        public string Password { get; set; }
        //[Required]
        //[Compare("Password", ErrorMessage = "Password mismatch")]
        //public string RePassword { get; set; }
        public string DeviceToken { get; set; }
        public string TimeZone { get; set; }
    }
}
