using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Lookups
    {
        public Lookups()
        {
            Customers = new HashSet<Customers>();
            Notifications = new HashSet<Notifications>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string LookupTitle { get; set; }
        public string LookupValue { get; set; }
        public string LookupType { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
