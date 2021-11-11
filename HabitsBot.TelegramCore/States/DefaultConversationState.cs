using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace HabitsBot.TelegramCore.States
{
    public class DefaultConversationState : ConversationState
    {
        public DefaultConversationState() : base()
        {

        }

        public override void AddHandler(string key, Action<ConversationDirector, MessageDto> handler)
        {
            _handlers.Add(key, handler);
        }

        public override void DeleteHandler(string key)
        {
            _handlers.Remove(key);
        }

        public override Action ExecuteState(ConversationDirector director, MessageDto message)
        {
            var command = message.Text;

            Action action = () => throw new NotImplementedException();

            if(_handlers.ContainsKey(command))
            {
                var handlerToExec = _handlers[command];
                
                action = () => { handlerToExec.Invoke(director, message); };
            }
            else
            {
                action = () => { };
            }

            return action;
        }
    }
}
