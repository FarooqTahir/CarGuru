using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.ApisDtos
{
    public class ConversationFileDto
    {
        public IFormFile files { get; set; }
    }
}
