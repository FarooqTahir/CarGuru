using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class FleetResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Vin { get; set; }
        public string PlateNo { get; set; }
        public string Mulkia { get; set; }
    }
}
