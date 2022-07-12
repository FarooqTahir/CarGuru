using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class ManualCallRecordDto
    {
        public long Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime ReceivedDate { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Year { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
    }
}
