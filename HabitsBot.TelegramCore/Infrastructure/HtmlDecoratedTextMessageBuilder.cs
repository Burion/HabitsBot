using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.Tests.Helpers;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class HtmlDecoratedTextMessageBuilder : DefaultTextMessageBuilder, ITextMessageBuilder
    {
        private readonly string _decoration;

        public HtmlDecoratedTextMessageBuilder(string decoration)
        {
            _decoration = decoration;
        }

        public override string BuildTextMessage(string message)
        {
            var messageToReturn = base.BuildTextMessage(message);

            return messageToReturn.ShieldHtmlTag(_decoration);
        }
    }
}
