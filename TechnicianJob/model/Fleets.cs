using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Fleets
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Vin { get; set; }
        public string PlateNo { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
