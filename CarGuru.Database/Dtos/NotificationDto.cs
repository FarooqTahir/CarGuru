using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public long NotificationTo { get; set; }
        public long NotificationFrom { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
        public int TypeId { get; set; }
        public LookupResponseDto Type { get; set; }
    }
}
