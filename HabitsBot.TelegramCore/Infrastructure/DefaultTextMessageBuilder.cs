using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class DefaultTextMessageBuilder : ITextMessageBuilder
    {
        public virtual TextMessageModel BuildTextMessage(string message)
        {
            var model = new TextMessageModel(message);

            return model;
        }
    }
}
