using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.BaseDto
{
 public   class LookupBaseDto
    {
        public int Id { get; set; }
        public string LookupTitle { get; set; }
        public string LookupValue { get; set; }
        public string LookupType { get; set; }
    }
}
