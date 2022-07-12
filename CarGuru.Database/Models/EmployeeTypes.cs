using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class EmployeeTypes
    {
        public EmployeeTypes()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
