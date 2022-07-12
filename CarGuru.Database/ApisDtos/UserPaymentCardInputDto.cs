using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
   public class UserPaymentCardInputDto
    {   
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Cvc { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressZip { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
    }
}
