using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class ConversationDirector : IConversationDirector
    {
        public IConversationState CurrentState { get; set; }
    }
}
