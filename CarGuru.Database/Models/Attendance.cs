﻿using System;
using System.Collections.Generic;

namespace CarGuru.Database.Models
{
    public partial class Attendance
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
