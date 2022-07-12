using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerInvoices = new HashSet<CustomerInvoices>();
            CustomerVehicles = new HashSet<CustomerVehicles>();
            Qoutations = new HashSet<Qoutations>();
            ServiceOrders = new HashSet<ServiceOrders>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? NoOfVehicles { get; set; }
        public string BillingAddress { get; set; }
        public string MulkiaNumber { get; set; }

        public virtual CustomerTypes CustomerType { get; set; }
        public virtual Lookups CustomerTypeNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CustomerInvoices> CustomerInvoices { get; set; }
        public virtual ICollection<CustomerVehicles> CustomerVehicles { get; set; }
        public virtual ICollection<Qoutations> Qoutations { get; set; }
        public virtual ICollection<ServiceOrders> ServiceOrders { get; set; }
    }
}
