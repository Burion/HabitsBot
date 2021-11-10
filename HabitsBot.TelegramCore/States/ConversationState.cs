using HabitsBot.TelegramCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace HabitsBot.TelegramCore.States
{
    public abstract class ConversationState
    {
        private readonly Dictionary<string, Action<IConversationDirector, MessageEventArgs>> _handlers;

        public abstract void AddHandler(string key, Action<IConversationDirector, MessageEventArgs> handler);
        public abstract void DeleteHandler(string key, Action<IConversationDirector, MessageEventArgs> handler);
        public abstract Action ExecuteState(IConversationDirector director, MessageEventArgs arguments);
    }
}
