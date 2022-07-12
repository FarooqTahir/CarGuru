using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class FeedbackRequestDto
    {
        [Required]
        public long ServiceOrderNo { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
