using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class CustomerVehicleDto
    {
        public long? Id { get; set; }
        public long UserId { get; set; }
        [Required]
        public string LicensePlateNumber { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Mulkia { get; set; }
    }
}
