using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class CustomerProfileListSpResponseDto
    {
        public int NoOfVehicle { get; set; }
        public long UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string ProfileUrl { get; set; }
    }
}
