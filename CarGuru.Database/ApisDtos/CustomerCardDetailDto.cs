using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class CustomerCardDetailDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CustomerId { get; set; }
    }
}
