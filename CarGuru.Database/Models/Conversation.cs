using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Conversation
    {
        public long ConversationId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public bool? IsActive { get; set; }
        public long? ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsFile { get; set; }
    }
}
