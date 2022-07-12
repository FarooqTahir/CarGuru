using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class MakePaymentInputDto
    {
        public int Amount { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
