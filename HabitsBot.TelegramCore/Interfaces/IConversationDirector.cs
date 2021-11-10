using HabitsBot.TelegramCore.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Interfaces
{
    public interface IConversationDirector
    {
        public IConversationState CurrentState { get; set; }
    }
}
