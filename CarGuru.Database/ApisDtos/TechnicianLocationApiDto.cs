using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class TechnicianLocationApiDto
    {
        public long TechnicianId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
