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
        public ITextMessageBuilder BaseBuilder { get; set; }

        public virtual string BuildTextMessage(string message)
        {
            string messageToReturn = message;
            
            if(BaseBuilder != null)
            {
                messageToReturn = BaseBuilder?.BuildTextMessage(message);
            }

            return messageToReturn;
        }
    }
}
