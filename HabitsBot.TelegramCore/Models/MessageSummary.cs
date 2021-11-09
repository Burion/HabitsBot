using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace HabitsBot.TelegramCore.Models
{
    public class MessageSummary
    {
        public string Message { get; set; }
        public ChatId ChatId { get; set; }
    }
}
