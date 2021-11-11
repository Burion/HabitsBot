using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace HabitsBot.TelegramCore.States
{
    public abstract class ConversationState
    {
        public ConversationState()
        {
            _handlers = new Dictionary<string, Action<ConversationDirector, MessageDto>>();
        }

        protected readonly Dictionary<string, Action<ConversationDirector, MessageDto>> _handlers;

        public abstract void AddHandler(string key, Action<ConversationDirector, MessageDto> handler);
        public abstract void DeleteHandler(string key);
        public abstract Action ExecuteState(ConversationDirector director, MessageDto message);
    }
}
