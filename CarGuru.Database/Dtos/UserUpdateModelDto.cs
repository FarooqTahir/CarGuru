using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class UserUpdateModelDto
    {
        public long UserId { get; set; }
        public string ProfileUrl { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
    }
}
