using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class ConversationMessageRequestDto
    {
        public long UserId { get; set; }
        public long OtherUserId { get; set; }
    }
}
