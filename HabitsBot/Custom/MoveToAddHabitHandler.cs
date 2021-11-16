using HabitsBot.Services.ClientServices;
using HabitsBot.Services.Interfaces;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Custom
{
    public class MoveToAddHabitHandler : Handler
    {
        public override void ExecuteHandler(ConversationDirector director, MessageDto message)
        {
            IChatService chatService = new ChatService();
            
            var chat = chatService.GetChatById(message.Chat.Id.ToString());
            chat.State = 1;
            
            chatService.EditChat(chat);

            var _message = "Please, enter name for new habit:";
            MessageComposer messageComposer = new MessageComposer(director, new MessageSummary() { ChatId = message.Chat.Id, Message = _message });
            var regular = new DefaultTextMessageBuilder();
            messageComposer.ComposeMessageDelegate(regular)();
        }
    }
}
