using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class Vendors
    {
        public Vendors()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessAddress { get; set; }
        public decimal CreditCardLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdateById { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
