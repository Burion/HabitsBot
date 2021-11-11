using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace HabitsBot.TelegramCore.Models
{
    public class MessageDto : Message
    {
        public MessageDto(Message message)
        {
            Chat = message.Chat;
            Text = message.Text;
            Caption = message.Caption;
        }
    }
}
