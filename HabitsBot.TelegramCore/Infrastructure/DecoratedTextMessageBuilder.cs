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

        public override TextMessageModel BuildTextMessage(string message)
        {
            var model = base.BuildTextMessage(message);

            model.Message = model.Message.ShieldHtmlTag(_decoration);

            return model;
        }
    }
}
