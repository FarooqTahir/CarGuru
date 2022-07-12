using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Employees
    {
        public long Id { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
