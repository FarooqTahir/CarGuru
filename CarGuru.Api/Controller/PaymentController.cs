using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Api.Utility;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Stripe;

namespace CarGuru.Api.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly StripeAPI _stripeApi;

        public PaymentController(IPaymentService paymentService, StripeAPI stripeApi)
        {
            _paymentService = paymentService;
            _stripeApi = stripeApi;
        }
        [HttpPost]
        public async Task<ResponseDto<object>> AddUserCard(UserPaymentCardInputDto customer)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            
            if(!(customer is null))
            {
                if(!(await _paymentService.CheckCustomerCard(customer.UserId)))
                {
                    var types = _stripeApi.CreateCustomer(customer);
                    if (types.Item1)
                    {
                        var userCard = new CustomerCardDetailDto()
                        {
                            UserId = customer.UserId,
                            CustomerId = types.Item2
                        };
                        await _paymentService.AddCustomerCard(userCard);
                        response.Data = types.Item2;
                        response.Status = 1;
                        return response;
                    }
                    response.Message = types.Item2;
                    response.Status = 0;
                    return response;
                }
                response.Message = "User Card Already Exist!";
                response.Status = 0;
                return response;

            }
            response.Status = 0;
            response.Message = "Invalid Card Details";
            return response;

        }
        [HttpPost]
        public async  Task<ResponseDto<object>> MakePayment(MakePaymentInputDto info)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            if (!(info is null))
            {
                string customerId = await _paymentService.GetCustomerIdByUserId(info.UserId);
                if (!string.IsNullOrEmpty(customerId))
                {
                    var types = _stripeApi.GetStripeCustomer(customerId);
                    if (!(types is null))
                    {
                        var c = new ChargeStripeCustomer()
                        {
                            Amount = info.Amount * 100,
                            Customer = customerId,
                            Currency = "usd",
                            Description = info.Description,
                            Capture = false,  //Don't capture the charge immediately
                        };
                        string ChargeId = _stripeApi.CaptureCharge(c);
                        if (!string.IsNullOrEmpty(ChargeId))
                        {
                            long CardId = await _paymentService.GetCardIdByUserId(info.UserId);
                            await _paymentService.MakeOrderPayment(info, ChargeId,CardId);
                            response.Data = ChargeId;
                            response.Status = 1;
                            return response;
                        }
                        response.Message = "Some Thing Went Wrong!";
                        response.Status = 0;
                        return response;
                    }
                    //response.Data = types.Item2;
                    response.Status = 0;
                    return response;
                }
                response.Status = 0;
                response.Message = "User Card Does Not Exist!";
                return response;

            }
            response.Status = 0;
            response.Message = "Invalid Card Details";
            return response;

        }
        [HttpPost]
        public async Task<ResponseDto<object>> CheckCustomerCardExist(IdDto model)
        {
            ResponseDto<object> response = new ResponseDto<object>();
            if (model.Id > 0)
            {
                string customerId = await _paymentService.GetCustomerIdByUserId(model.Id);
                if (!string.IsNullOrEmpty(customerId))
                {
                    response.Data = true;
                    response.Message = "Card Exist";
                    response.Status = 1;
                    return response;
                }
            }
            response.Status = 0;
            response.Data = false;
            response.Message = "No Card Exist";
            return response;
        }
    }
}