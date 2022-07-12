using CarGuru.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface INotificationService
    {
        public Task<ResponseDto<NotificationDto>> Create(NotificationDto model);
        public Task<ResponseDto<List<NotificationDto>>> List(long UserId);
        public Task<ResponseDto<PushQueueDto>> CreatePushQueue(PushQueueDto model);
        public Task<ResponseDto<bool>> Read(long UserId);
    }
}