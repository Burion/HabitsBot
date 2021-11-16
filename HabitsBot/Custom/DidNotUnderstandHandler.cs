using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Custom
{
    public class DidNotUnderstandHandler : Handler
    {
        public override void ExecuteHandler(ConversationDirector director, MessageDto message)
        {
            MessageComposer messageComposer = new MessageComposer(director, new MessageSummary() { ChatId = message.Chat.Id, Message = "Sorry, I didn't understand your command." });

            var regular = new DefaultTextMessageBuilder();

            messageComposer.ComposeMessageDelegate(regular)();
        }
    }
}
