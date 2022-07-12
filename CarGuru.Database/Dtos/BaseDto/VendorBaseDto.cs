using System;
using System.ComponentModel.DataAnnotations;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class VendorBaseDto
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessAddress { get; set; }
        public decimal CreditCardLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
    }
}