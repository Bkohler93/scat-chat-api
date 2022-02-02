using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scat_chat_api.Dtos.Scat
{
    public class AddScatDto
    {
        public string? Text { get; set; }
        public string? Author {get; set;}
        public string? Color { get; set; }
        public int UserId { get; set; } = 1;
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public int NumLikes { get; set; } = 0;
    }
}