using HabitsBot.Helpers;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using HabitsBot.TelegramCore.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot
{
    public class Startup : StartupBase
    {
        public override void RunApplication()
        {
            var config = ConfigHandler.GetJsonConfigurationFromPath("appSettings.json");

            ConversationDirector director = new ConversationDirector(config.GetSection("token").Value);
            var state = new DefaultConversationState();

            Action<ConversationDirector, MessageDto> handlerMessageDelegate =
                (d, m) => {
                    MessageComposer messageComposer = new MessageComposer(d, new MessageSummary() { ChatId = m.Chat.Id, Message = "Hello! I am HabitsBot - your daily helper in habits activity!" });

                    var italic = new ItalicTextMessageBuilder();

                    messageComposer.ComposeMessageDelegate(italic)();
                };

            state.AddHandler("/start", handlerMessageDelegate);

            director.SetState(state);

            director.InitializeReceiving();
        }
    }
}
