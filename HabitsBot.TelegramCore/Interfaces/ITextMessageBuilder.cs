using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Interfaces
{
    public interface ITextMessageBuilder
    {
        ITextMessageBuilder BaseBuilder { get; set; }
        string BuildTextMessage(string message);
    }
}
