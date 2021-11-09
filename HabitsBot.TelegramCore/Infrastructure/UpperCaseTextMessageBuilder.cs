using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class UpperCaseTextMessageBuilder : DefaultTextMessageBuilder, ITextMessageBuilder
    {
        public override string BuildTextMessage(string message)
        {
            var messageToReturn = base.BuildTextMessage(message);
            
            return messageToReturn.ToUpper(); 
        }
    }
}
