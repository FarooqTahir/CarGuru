using CarGuru.Database.ApisDtos;
using ServiceStack.Stripe;
using ServiceStack.Stripe.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarGuru.Api.Utility
{
    public class StripeAPI
    {
        StripeGateway gateway = new StripeGateway("sk_test_51HCKf2AyfOTca4NN6FhBCk3jptJyhtBAMBidzZ6t0KBqiSFI4JzNT7IU3b9oCdVx70pFI4E4MbdsOkqCJRFjGWIQ00TJN1IT5T");

        public StripeCustomer GetStripeCustomer(string userId)
        {
           return gateway.Get(new GetStripeCustomer { Id = userId });
        }

        public (bool, string) CreateCustomer(UserPaymentCardInputDto p)
        {
            try
            {
                var cardToken = gateway.Post(new CreateStripeToken
                {
                    Card = new StripeCard
                    {
                        Name = p.CardHolderName,
                        Number = p.CardNumber,
                        Cvc = p.Cvc,
                        ExpMonth = p.ExpMonth,
                        ExpYear = p.ExpYear,
                        AddressLine1 = p.AddressLine1,
                        AddressLine2 = p.AddressLine2,
                        AddressZip = p.AddressZip,
                        AddressState = p.AddressState,
                        AddressCountry = p.AddressCountry,
                    },
                });
                var customer = gateway.Post(new CreateStripeCustomerWithToken
                {
                    Card = cardToken.Id,
                    Email = p.Email,
                });
                return (true,customer.Id);
            }
            catch (Exception ex)
            {
                return (false,Convert.ToString(ex.Message));
            }
            
        }

        

        public string CaptureCharge(ChargeStripeCustomer p)
        {
            var charge = gateway.Post(new ChargeStripeCustomer
            {
                Amount = p.Amount,
                Customer = p.Customer,
                Currency = "usd",
                Description = p.Description,
                Capture = false,  //Don't capture the charge immediately
            });

            //Can capture charge later with an explicit call
            var captureCharge = gateway.Post(new CaptureStripeCharge
            {
                ChargeId = charge.Id,
            });

            return captureCharge.Id;
        }

        public string DeleteCustomer(string customerId)
        {
            return gateway.Delete(new DeleteStripeCustomer { Id = customerId }).Id;
        }
    }
}
