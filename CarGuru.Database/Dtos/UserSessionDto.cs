using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class UserSessionDto
    {
        public long UserId { get; set; }
        public int UserRoleId { get; set; }
        public string TimeZoneId { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
    }
}
