using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class FleetRequestDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string PlateNo { get; set; }
        public string Vin { get; set; }
        public string Mulkia { get; set; }
    }
}
