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
        internal ConversationState CurrentState { get; set; }

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

            BotClient.OnMessage += (e, a) => CurrentState.ExecuteState(this, new MessageDto(a.Message))();
        }

        public void ShutDown()
        {
            BotClient.StopReceiving();
        }
    }
}
