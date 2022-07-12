using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class AttendanceAPiDto
    {
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
