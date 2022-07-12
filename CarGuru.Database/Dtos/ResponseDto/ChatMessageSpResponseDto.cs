using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class FromUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProfileUrl { get; set; }
    }

    public class ToUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProfileUrl { get; set; }
    }

    public class Chat
    {
        public int ConversationId { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSent { get; set; }
        public bool IsFile { get; set; }
    }
    public class MessageObj
    {
        public long OtherUserId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsFile { get; set; }
    }

    public class NewMessage
    {
        public MessageObj MessageObj { get; set; }
    }
    public class ChatMessageSpResponseDto
    {
        ChatMessageSpResponseDto() 
        {
            NewMessages = new List<NewMessage>();
        }
        public FromUser FromUser { get; set; }
        public ToUser ToUser { get; set; }
        public List<Chat> Chat { get; set; }
        public List<NewMessage> NewMessages { get; set; }
    }
    public class UserChat
    {
        public int OtherUserId { get; set; }
        public bool IsFile { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public object ProfileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ChatMessageSpMobileResponseDto
    {
        ChatMessageSpMobileResponseDto()
        {
            UserChats = new List<UserChat>();
        }
        public FromUser FromUser { get; set; }
        public ToUser ToUser { get; set; }
        public List<Chat> Chat { get; set; }
        public List<UserChat> UserChats { get; set; }
    }
}
