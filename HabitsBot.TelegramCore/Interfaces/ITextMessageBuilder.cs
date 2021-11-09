using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Interfaces
{
    interface ITextMessageBuilder
    {
        TextMessageModel BuildTextMessage(string message);
    }
}
