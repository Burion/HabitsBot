using HabitsBot.TelegramCore.States;
using HabitsBot.TelegramCore.States.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Custom.States
{
    public class AddingHabitState : DefaultConversationState
    {
        public AddingHabitState()
        {
            AddHandler(new AddHabitHandler(), MessageHandleType.FreeText);
        }
    }
}
