using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class CustomerCustomRequestDto
    {
        public IFormFile files { get; set; }
        public string Customer { get; set; }
    }
}
