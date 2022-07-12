using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class ChatSession
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
