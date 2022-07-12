using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class UpdateTechnicianRequestDto
    {
        public IFormFile files { get; set; }
        public string Technician { get; set; }
    }
}
