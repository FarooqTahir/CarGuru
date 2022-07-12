using CarGuru.Database.ApisDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task<long> AddCustomerCard(CustomerCardDetailDto model);
        public Task<bool> CheckCustomerCard(long userId = 0);
        public Task<string> GetCustomerIdByUserId(long userId = 0);
        public Task<bool> MakeOrderPayment(MakePaymentInputDto model,string ChargeId,long CardId);
        public Task<long> GetCardIdByUserId(long userId = 0);
    }
}
