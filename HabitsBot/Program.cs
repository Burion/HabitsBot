using HabitsBot.Helpers;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HabitsBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigHandler.GetJsonConfigurationFromPath("appSettings.json");

            var botClient = new TelegramBotClient(config.GetSection("token").Value);

            botClient.StartReceiving();

            botClient.OnMessage += (e, a) =>
            {
                StringBuilder sb = new StringBuilder("<b>hello</b>");
                

                // Buttons
                InlineKeyboardButton urlButton = new InlineKeyboardButton();
                InlineKeyboardButton urlButton2 = new InlineKeyboardButton();

                urlButton.Text = "Go URL1";

                urlButton.Url = "https://www.google.com/";

                urlButton2.Text = "Go URL2";
                urlButton2.Url = "https://www.bing.com/";



                InlineKeyboardButton[] buttons = new InlineKeyboardButton[] { urlButton, urlButton2 };

                // Keyboard markup
                InlineKeyboardMarkup inline = new InlineKeyboardMarkup(buttons);

                // Send message!
                MessageEntity entity = new MessageEntity();
                entity.Type = MessageEntityType.Bold;

                var messageSummary = new MessageSummary()
                {
                    Message = "Hello! This is new message from me!",
                    ChatId = a.Message.Chat.Id
                };

                MessageComposer messageComposer = new MessageComposer(botClient, messageSummary);

                var italic = new ItalicTextMessageBuilder();
                var upper = new UpperCaseTextMessageBuilder();

                italic.BaseBuilder = upper;

                messageComposer.ComposeMessageDelegate(italic)();

                //botClient.SendTextMessageAsync(a.Message.Chat.Id, sb.ToString(), ParseMode.Html, new MessageEntity[] { entity, entity, entity }, false, false, 0, false, inline);
                //botClient.SendTextMessageAsync(a.Message.Chat.Id, "I'm working!");
            };

            while(true)
            {

            }

            botClient.StopReceiving();
        }
    }
}
