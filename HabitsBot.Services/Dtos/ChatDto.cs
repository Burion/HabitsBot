using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Services.Dtos
{
    public class ChatDto
    {
        public string Id { get; set; }
        public int State { get; set; }
        public string UserId { get; set; }
    }
}
