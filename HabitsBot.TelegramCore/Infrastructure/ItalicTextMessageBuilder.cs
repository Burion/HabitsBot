using HabitsBot.TelegramCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class ItalicTextMessageBuilder : HtmlDecoratedTextMessageBuilder, ITextMessageBuilder
    {
        private const string ITALIC_TAG = "<i>";

        public ItalicTextMessageBuilder() : base(ITALIC_TAG) { }
    }
}
