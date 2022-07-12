using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Lookups
    {
        public Lookups()
        {
            Customers = new HashSet<Customers>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string LookupTitle { get; set; }
        public string LookupValue { get; set; }
        public string LookupType { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
