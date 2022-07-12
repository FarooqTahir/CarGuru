using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PaymentService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<long> AddCustomerCard(CustomerCardDetailDto model)
        {
            if (!(await CheckCustomerCard(model.UserId)))
            {
                var customerCard = _mapper.Map<CustomerCardDetailDto, CustomerCardDetail>(model);
                _db.CustomerCardDetail.Add(customerCard);
                await _db.SaveChangesAsync();
                return customerCard.Id;
            }
            return 0;
        }
        public async Task<bool> CheckCustomerCard(long userId = 0)
        {
            if(userId > 0)
            {
                var card = await _db.CustomerCardDetail.FirstOrDefaultAsync(a => a.UserId == userId);
                if (!(card is null))
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<string> GetCustomerIdByUserId(long userId = 0)
        {
            if (userId > 0)
            {
                var card = await _db.CustomerCardDetail.FirstOrDefaultAsync(a => a.UserId == userId);
                if (!(card is null))
                {
                    return card.CustomerId;
                }
            }
            return "";
        }
        public async Task<long> GetCardIdByUserId(long userId = 0)
        {
            if (userId > 0)
            {
                var card = await _db.CustomerCardDetail.FirstOrDefaultAsync(a => a.UserId == userId);
                if (!(card is null))
                {
                    return card.Id;
                }
            }
            return 0;
        }
        public async Task<bool> MakeOrderPayment(MakePaymentInputDto model,string ChargeId,long CardId)
        {
            if (!(model is null))
            {
                var payment = _mapper.Map<MakePaymentInputDto,CustomerPaymentDetail>(model);
                payment.Currency = "USD";
                payment.ChargeId = ChargeId;
                payment.CardDetailId = CardId;
                _db.CustomerPaymentDetail.Add(payment);
                await _db.SaveChangesAsync();
                if (payment.OrderId > 0)
                {
                    string OrderStatus = Convert.ToString(payment.OrderId);
                    var ServiceOrder = await _db.ServiceOrders.FirstOrDefaultAsync(a => a.ServiceOrderNo.Equals(OrderStatus));
                    if(!(ServiceOrder is null))
                    {
                        ServiceOrder.OrderStatusId = 2010;
                    await _db.SaveChangesAsync();
                    }
                }
            }
            return true;
        }
    }
}
