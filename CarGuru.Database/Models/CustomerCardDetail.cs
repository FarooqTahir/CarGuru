using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class CustomerCardDetail
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CustomerId { get; set; }
    }
}
