using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public abstract class Handler
    {
        public abstract void ExecuteHandler(ConversationDirector director, MessageDto message);
    }
}
