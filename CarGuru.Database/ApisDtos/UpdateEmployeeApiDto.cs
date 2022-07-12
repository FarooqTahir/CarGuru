using CarGuru.Database.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class UpdateEmployeeApiDto
    {
        public long UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int GenderId { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Fees")]
        public decimal Fees { get; set; }
        public string ProfileUrl { get; set; }

    }
}
