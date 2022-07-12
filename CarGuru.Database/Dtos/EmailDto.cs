using System.Collections.Generic;

namespace CarGuru.Database.Dtos
{
    public class EmailDto
    {
        public EmailDto() 
        {
            ToEmails =new List<string>();
        }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> ToEmails { get; set; }
    }
}