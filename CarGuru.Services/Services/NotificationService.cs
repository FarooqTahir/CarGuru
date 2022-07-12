using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarGuru.Services.Services
{
    public class NotificationService: INotificationService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public NotificationService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<NotificationDto>> Create(NotificationDto model)
        {
            var mappedObject = _mapper.Map<NotificationDto, Notifications>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            _db.Notifications.Add(mappedObject);
            var result = await _db.SaveChangesAsync();
            if (result > 0) 
            {
                return new ResponseDto<NotificationDto>() { Data = model, Status = 1, Message = "Success" };
            }
            return new ResponseDto<NotificationDto>() { Data = model,Status=0,Message="Error" };
        }
        public async Task<ResponseDto<List<NotificationDto>>> List(long UserId)
        {
            var dbList = await _db.Notifications.Include(x => x.Type).Where(x=>x.NotificationTo == UserId).OrderByDescending(a => a.CreatedDate).ToListAsync();
            var List = _mapper.Map<List<Notifications>, List<NotificationDto>>(dbList);
            if (List.Count > 0)
            {
                return new ResponseDto<List<NotificationDto>>() { Data = List, Status = 1, Message = "Success" };
            }
            return new ResponseDto<List<NotificationDto>>() { Data = List, Status = 0, Message = "No Record Found" };
        }
        public async Task<ResponseDto<bool>> Read(long UserId)
        {
            var dbList = await _db.Notifications.Where(x => x.NotificationTo == UserId && !(x.IsRead)).ToListAsync();
            if(!(dbList is null) && dbList.Any())
            {
                foreach(var noti in dbList)
                {
                    noti.IsRead = true;
                }
                await _db.SaveChangesAsync();
            }
           
            return new ResponseDto<bool>() { Data = true, Status = 1 };
        }
        public async Task<ResponseDto<PushQueueDto>> CreatePushQueue(PushQueueDto model)
        {
            var mappedObject = _mapper.Map<PushQueueDto, NotificationQueue>(model);
            
            _db.NotificationQueue.Add(mappedObject);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseDto<PushQueueDto>() { Data = model, Status = 1, Message = "Success" };
            }
            return new ResponseDto<PushQueueDto>() { Data = model, Status = 0, Message = "Error" };
        }
    }
}
