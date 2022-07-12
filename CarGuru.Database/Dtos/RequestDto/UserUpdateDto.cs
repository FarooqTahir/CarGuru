using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class UserUpdateDto
    {
        public long UserId { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
        public string ProfileUrl { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
    }
}
