using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.TelegramCore.States;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class ConversationDirector
    {
        internal TelegramBotClient BotClient { get; }
        public ConversationState CurrentState { get; set; }

        public ConversationDirector(string botToken)
        {
            BotClient = new TelegramBotClient(botToken);
        }

        public void SetState(ConversationState state)
        {
            CurrentState = state;
        }

        public void InitializeReceiving()
        {
            BotClient.StartReceiving();
        }

        //public Action<ConversationDirector, string> ResolveConversationStateDelegate { get; set; }

        public virtual void InitializeOnMessageHandlers(params Handler[] handlers)
        {
            foreach (var handler in handlers)
            {
                BotClient.OnMessage += (e, a) => handler.ExecuteHandler(this, new MessageDto(a.Message));
            }

            BotClient.OnMessage += (e, a) =>
            {
                CurrentState.ExecuteState(this, new MessageDto(a.Message))();
            };
        }

        public void ShutDown()
        {
            BotClient.StopReceiving();
        }
    }
}
