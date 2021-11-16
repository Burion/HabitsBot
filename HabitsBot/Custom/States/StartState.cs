using HabitsBot.TelegramCore.States;
using HabitsBot.TelegramCore.States.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Custom.States
{
    public class StartState : DefaultConversationState 
    {
        public StartState()
        {
            AddHandler("/start", new StartHandler());
            AddHandler("/add_habit", new MoveToAddHabitHandler());
            AddHandler(new DidNotUnderstandHandler(), MessageHandleType.Error);
        }
    }
}
