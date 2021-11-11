using HabitsBot.Helpers;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using HabitsBot.TelegramCore.States;
using HabitsBot.TelegramCore.States.Configurations;
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

            var greetedState = new DefaultConversationState();
            Action<ConversationDirector, MessageDto> echoDelegate =
                (d, m) => {
                    MessageComposer messageComposer = new MessageComposer(d, new MessageSummary() { ChatId = m.Chat.Id, Message = m.Text });

                    var italic = new ItalicTextMessageBuilder();

                    messageComposer.ComposeMessageDelegate(italic)();
                };

            var state = new DefaultConversationState();
            Action<ConversationDirector, MessageDto> handlerMessageDelegate =
                (d, m) => {
                    MessageComposer messageComposer = new MessageComposer(d, new MessageSummary() { ChatId = m.Chat.Id, Message = "Hello! I am HabitsBot - your daily helper in habits activity!" });

                    var regular = new DefaultTextMessageBuilder();

                    messageComposer.ComposeMessageDelegate(regular)();

                    d.SetState(greetedState);
                };
            Action<ConversationDirector, MessageDto> errorMessageDelegate =
                (d, m) => {
                    MessageComposer messageComposer = new MessageComposer(d, new MessageSummary() { ChatId = m.Chat.Id, Message = "Sorry, I didn't understand your command." });

                    var regular = new DefaultTextMessageBuilder();

                    messageComposer.ComposeMessageDelegate(regular)();
                };
            Action<ConversationDirector, MessageDto> languageMessageDelegate =
                (d, m) => {
                    MessageComposer messageComposer = new MessageComposer(d, new MessageSummary() { ChatId = m.Chat.Id, Message = "Please, select languge you prefer:" });

                    var regular = new DefaultTextMessageBuilder();

                    messageComposer.ComposeMessageDelegate(regular)();
                };

            state.AddHandler("/start", handlerMessageDelegate);
            state.AddHandler(errorMessageDelegate, MessageHandleType.Error);

            greetedState.AddHandler(echoDelegate, MessageHandleType.FreeText);

            director.SetState(state);
            
            Random r = new Random();
            ConversationState[] states = { state, greetedState };
            director.InitializeOnMessageHandlers(
                () => {
                    director.SetState(states[r.Next(0, 100) > 50 ? 0 : 1]);
                });
            director.InitializeReceiving();
        }
    }
}
