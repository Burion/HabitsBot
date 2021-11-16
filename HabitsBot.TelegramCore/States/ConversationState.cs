using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.TelegramCore.States.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace HabitsBot.TelegramCore.States
{
    public abstract class ConversationState
    {
        public ConversationState()
        {
            _handlers = new Dictionary<string, Handler>();
        }

        protected readonly Dictionary<string, Handler> _handlers;

        public abstract void AddHandler(string key, Handler handler);
        public abstract void AddHandler(Handler handler, MessageHandleType type);
        public abstract void DeleteHandler(string key);
        public abstract Action ExecuteState(ConversationDirector director, MessageDto message);
        protected Handler FreeMessageHandler { get; set; }
        protected Handler ErrorHandler { get; set; }
    }
}
