using System;
using System.Collections.Generic;

namespace PushNotificationJob.model
{
    public partial class ProductsInQoutations
    {
        public long Id { get; set; }
        public long QoutationId { get; set; }
        public long? ProductId { get; set; }
        public long ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Products Product { get; set; }
        public virtual Qoutations Qoutation { get; set; }
    }
}
