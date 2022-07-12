using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class CustomerTypes
    {
        public CustomerTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public short? Margin { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
