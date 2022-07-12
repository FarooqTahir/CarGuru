using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class MConversationDto
    {
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public bool IsFile { get; set; } = false;
    }
}
