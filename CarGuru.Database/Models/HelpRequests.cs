using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class HelpRequests
    {
        public long Id { get; set; }
        public string HelpRequest { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
