using System;
using System.Collections.Generic;

namespace TechnicianJob.model
{
    public partial class Users
    {
        public Users()
        {
            CustomerInvoices = new HashSet<CustomerInvoices>();
            CustomerVehicles = new HashSet<CustomerVehicles>();
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
            UserDevices = new HashSet<UserDevices>();
        }

        public long UserId { get; set; }
        public int? RoleId { get; set; }
        public int? GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SessionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }

        public virtual Lookups Gender { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ICollection<CustomerInvoices> CustomerInvoices { get; set; }
        public virtual ICollection<CustomerVehicles> CustomerVehicles { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<UserDevices> UserDevices { get; set; }
    }
}
