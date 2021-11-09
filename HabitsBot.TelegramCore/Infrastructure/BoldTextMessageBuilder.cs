using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class BoldTextMessageBuilder : HtmlDecoratedTextMessageBuilder, ITextMessageBuilder
    {
        private const string BOLD_TAG = "<b>";

        public BoldTextMessageBuilder() : base(BOLD_TAG) { }
    }
}
