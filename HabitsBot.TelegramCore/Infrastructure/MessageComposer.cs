using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace HabitsBot.TelegramCore.Infrastructure
{
    public class MessageComposer
    {
        private readonly TelegramBotClient _botClient;
        private readonly MessageSummary _messageSummary;

        public MessageComposer(TelegramBotClient botClient, MessageSummary messageSummary)
        {
            _botClient = botClient;
            _messageSummary = messageSummary;
        }

        public Action ComposeMessageDelegate(ITextMessageBuilder textMessageBuilder)
        {
            var textMessageModel = textMessageBuilder.BuildTextMessage(_messageSummary.Message);

            Action sendMessageDelegate = () =>
            {
                _botClient.SendTextMessageAsync(
                    _messageSummary.ChatId,
                    textMessageModel,
                    ParseMode.Html, null, false, false, 0, false, null);
            };

            return sendMessageDelegate;
        }
    }
}
