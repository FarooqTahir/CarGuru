using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ServiceType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int? Priority { get; set; }
        public bool? IsActive { get; set; }
    }
}
