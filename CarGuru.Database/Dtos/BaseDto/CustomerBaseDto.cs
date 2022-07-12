using CarGuru.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class CustomerBaseDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Required]
        public int? CustomerTypeId { get; set; }
        public int? NoOfVehicles { get; set; }
        public string BillingAddress { get; set; }
    }
}