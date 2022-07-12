using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class ConversationService : IConversationService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public ConversationService(ApplicationDbContext dbContext, IMapper mapper,IConfiguration config,IUserService userService,INotificationService notificationService
        )
        {
            _db = dbContext;
            _mapper = mapper;
            _config = config;
            _userService = userService;
            _notificationService = notificationService;
        }
        public async Task<ResponseDto<ChatMessageSpResponseDto>> GetChatMessagesById(long userId, long otherUserId)
        {
            await using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetUserChat]", param: new { UserId = userId,OtherUserId = otherUserId },
                commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<ChatMessageSpResponseDto>(builder.ToString());
                if(!(response.NewMessages is null))
                {
                    response.NewMessages = response.NewMessages.Where(x => x.MessageObj != null).ToList();
                }
                return new ResponseDto<ChatMessageSpResponseDto>()
                {
                    Data = response
                };
            }
        }
        public async Task<ResponseDto<List<ConversationDto>>> GetConversationByUserId(long userId,long otherUserId)
        {
            var conversation = await _db.Conversation.Where(a => (a.FromUserId == userId || a.ToUserId == userId) && (a.ToUserId == otherUserId || a.FromUserId == otherUserId) && a.IsActive.Value).ToListAsync();
            var response = _mapper.Map<List<Conversation>, List<ConversationDto>>(conversation);
            return new ResponseDto<List<ConversationDto>>() { Data = response };
        }
        public async Task<ResponseDto<ConversationDto>> AddConversationMessage(ConversationDto model)
        {
            if (!(model is null))
            {
                var request = _mapper.Map<ConversationDto, Conversation>(model);
                string senderName = "";
                request.CreatedDate = DateTime.UtcNow;
                request.IsActive = true;
                _db.Conversation.Add(request);
                await _db.SaveChangesAsync();
                var user = await GetByUserId(model.FromUserId);
                if (!(user is null))
                {
                    senderName = user.FirstName + " " + user.LastName;
                }
                var Notification = new NotificationDto()
                {
                    NotificationTo = model.ToUserId,
                    NotificationFrom = model.FromUserId,
                    Message = senderName + " Sent New Message",
                    TypeId = Convert.ToInt32(NotificationTypes.NewMessage)
                };
                await _notificationService.Create(Notification);
                var Devices = await _userService.GetUserDevices(model.ToUserId);
                if (!(Devices.Data is null) && Devices.Data.Any())
                {
                    foreach (var device in Devices.Data)
                    {
                        Common.SendPushNotification(device.DeviceToken, PushNotifications.NewMessage);
                    }
                }
                var response = _mapper.Map<Conversation, ConversationDto>(request);

                return new ResponseDto<ConversationDto>() { Data = response };
            }
            return new ResponseDto<ConversationDto>() { Data = new ConversationDto() };
        }
        public async Task<ResponseDto<ConversationDto>> GetSingleMessage(long conversationId)
        {
            if (conversationId > 0)
            {
                var conversation = await _db.Conversation.FirstOrDefaultAsync(a => a.ConversationId == conversationId);
                if (!(conversation is null))
                {
                    var response = _mapper.Map<Conversation, ConversationDto>(conversation);
                    return new ResponseDto<ConversationDto>() { Data = response };
                }
            }
            return new ResponseDto<ConversationDto>() { Data = new ConversationDto() };
        }
        public async Task<ResponseDto<ConversationDto>> EditConversationMessage(ConversationDto model)
        {
            if (!(model is null))
            {
                var request = _mapper.Map<ConversationDto, Conversation>(model);
                var conversation = await _db.Conversation.FirstOrDefaultAsync(a => a.ConversationId == model.ConversationId);
                if(!(conversation is null))
                {
                    conversation.Message = model.Message;
                    _db.Entry(conversation).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    var response = _mapper.Map<Conversation, ConversationDto>(conversation);
                    return new ResponseDto<ConversationDto>() { Data = response };
                }
            }
            return new ResponseDto<ConversationDto>() { Data = new ConversationDto() };
        }
        public async Task<ResponseDto<bool>> DeleteMessage(long conversationId)
        {
            if (conversationId > 0)
            {
                var conversation = await _db.Conversation.FirstOrDefaultAsync(a => a.ConversationId == conversationId);
                if (!(conversation is null))
                {
                    conversation.IsActive = false;
                    _db.Entry(conversation).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new ResponseDto<bool>() { Data = true };
                }
            }
            return new ResponseDto<bool>() { Data = false};
        }
        public async Task<ResponseDto<bool>> ReadMessage(long conversationId)
        {
            if (conversationId > 0)
            {
                var conversation = await _db.Conversation.FirstOrDefaultAsync(a => a.ConversationId == conversationId);
                if (!(conversation is null))
                {
                    conversation.IsRead = true;
                    _db.Entry(conversation).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new ResponseDto<bool>() { Data = true };
                }
            }
            return new ResponseDto<bool>() { Data = false };
        }
        public async Task<ResponseDto<bool>> ReadConversationMessage(long toUserId,long fromUserId)
        {
            if (toUserId > 0 && fromUserId > 0)
            {
                var conversation = await _db.Conversation.Where(a => a.ToUserId == toUserId && a.FromUserId == fromUserId).ToListAsync();
                if (!(conversation is null) && conversation.Any())
                {
                    foreach(var mess in conversation)
                    {
                        mess.IsRead = true;
                        _db.Entry(mess).State = EntityState.Modified;
                    }
                    await _db.SaveChangesAsync();
                    return new ResponseDto<bool>() { Data = true };
                }
            }
            return new ResponseDto<bool>() { Data = false };
        }
        public bool SendPushNotificationForMessage(string deviceId, string message)
        {
            try
            {
                string senderId = _config.GetValue<string>("FireBaseKeys:SenderId");
                string serverKey = _config.GetValue<string>("FireBaseKeys:ServerKey"); 
                //string deviceId = "ch_G60NPga4:APA9............T_LH8up40Ghi-J";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    data = new
                    {
                        msg = message,
                        type = "Chat",
                        title = "Car Guru",
                        click_action = "Chat"
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }


            }

            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return false;
        }

        public async Task<ResponseDto<ConversationDto>> AddConversationMessage(MConversationDto model)
        {
            if (!(model is null))
            {
                var request = _mapper.Map<MConversationDto, Conversation>(model);
                string senderName = "";
                request.CreatedDate = DateTime.UtcNow;
                request.IsActive = true;
                _db.Conversation.Add(request);
                await _db.SaveChangesAsync();
                var user = await GetByUserId(model.FromUserId);
                if (!(user is null))
                {
                    senderName = user.FirstName + " " + user.LastName;
                }
                var Notification = new NotificationDto()
                {
                    NotificationTo = model.ToUserId,
                    NotificationFrom = model.FromUserId,
                    Message = senderName + " Sent New Message",
                    TypeId = Convert.ToInt32(NotificationTypes.NewMessage)
                };
                await _notificationService.Create(Notification);
                var Devices = await _userService.GetUserDevices(model.ToUserId);
                if (!(Devices.Data is null) && Devices.Data.Any())
                {
                    foreach (var device in Devices.Data)
                    {
                        Common.SendPushNotification(device.DeviceToken, PushNotifications.NewMessage.ToString());
                    }
                }
                var response = _mapper.Map<Conversation, ConversationDto>(request);

                return new ResponseDto<ConversationDto>() { Data = response };
            }
            return new ResponseDto<ConversationDto>() { Data = new ConversationDto() };
        }
        public async Task<UserUpdateDto> GetByUserId(long Id)
        {
            var User = await _db.Users.Where(x => x.UserId == Id).FirstOrDefaultAsync();
            UserUpdateDto model = new UserUpdateDto();
            if (User != null)
            {
                model = _mapper.Map<Users, UserUpdateDto>(User);
                return model;
            }
            return model;

        }
        public List<long> AgentsAvailable()
        {
            var List = _db.Users.Where(a => a.RoleId.Value == Convert.ToInt64(UserRoles.Agent)).Select(x => x.UserId).ToList();
            return List;
        }

        public async Task<ResponseDto<ChatMessageSpMobileResponseDto>> GetChatMessagesByIdMobile(long userId, long otherUserId)
        {
            await using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetUserChatMobile]", param: new { UserId = userId, OtherUserId = otherUserId },
                commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<ChatMessageSpMobileResponseDto>(builder.ToString());
               
                return new ResponseDto<ChatMessageSpMobileResponseDto>()
                {
                    Data = response
                };
            }
        }
    }
}
