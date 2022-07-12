using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Interfaces
{
    public interface IConversationService
    {
        public Task<ResponseDto<List<ConversationDto>>> GetConversationByUserId(long userId, long otherUserId);
        public Task<ResponseDto<ConversationDto>> AddConversationMessage(ConversationDto model);
        public Task<ResponseDto<ConversationDto>> AddConversationMessage(MConversationDto model);
        public Task<ResponseDto<ConversationDto>> GetSingleMessage(long conversationId);
        public Task<ResponseDto<ConversationDto>> EditConversationMessage(ConversationDto model);
        public Task<ResponseDto<bool>> DeleteMessage(long conversationId);
        public Task<ResponseDto<bool>> ReadMessage(long conversationId);
        public Task<ResponseDto<bool>> ReadConversationMessage(long toUserId, long fromUserId);
        public Task<ResponseDto<ChatMessageSpResponseDto>> GetChatMessagesById(long userId, long otherUserId);
        public Task<ResponseDto<ChatMessageSpMobileResponseDto>> GetChatMessagesByIdMobile(long userId, long otherUserId);
        List<long> AgentsAvailable();
    }
}
