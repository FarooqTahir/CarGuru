using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ConversationDto
    {
        public long ConversationId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
