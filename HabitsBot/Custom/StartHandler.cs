using HabitsBot.Services.ClientServices;
using HabitsBot.Services.Dtos;
using HabitsBot.Services.Interfaces;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace HabitsBot.Custom
{
    public class StartHandler : Handler
    {
        public override void ExecuteHandler(ConversationDirector director, MessageDto message)
        {
            IChatService chatsService = new ChatService();
            var chat = chatsService.GetChatById(message.Chat.Id.ToString());
            var _message = "";

            if (chat == null)
            {
                _message = "Welcome! I see you are first time here, so let me note you im my database :)";
                var chatModel = new ChatDto()
                {
                    Id = message.Chat.Id.ToString(),
                    State = 0,
                    UserId = message.Chat.Username
                };

                chat = chatsService.AddChat(chatModel);
            }
            else
            {
                _message = "Welcome back!";
            }

            MessageComposer messageComposer = new MessageComposer(director, new MessageSummary() { ChatId = message.Chat.Id, Message = _message });
            var regular = new DefaultTextMessageBuilder();
            messageComposer.ComposeMessageDelegate(regular)();
        }
    }
}
