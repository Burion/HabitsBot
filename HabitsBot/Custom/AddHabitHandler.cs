using HabitsBot.Services.ClientServices;
using HabitsBot.Services.Dtos;
using HabitsBot.Services.Interfaces;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Custom
{
    public class AddHabitHandler : Handler
    {
        public override void ExecuteHandler(ConversationDirector director, MessageDto message)
        {
            IHabitsService habitsService = new HabitsService();
            IChatService chatService = new ChatService();

            var habit = new HabitDto()
            {
                ChatId = message.Chat.Id.ToString(),
                Name = message.Text
            };

            habitsService.AddHabit(habit);

            var chat = chatService.GetChatById(message.Chat.Id.ToString());
            chat.State = 0;
            chatService.EditChat(chat);

            MessageComposer messageComposer = new MessageComposer(director, new MessageSummary() { ChatId = message.Chat.Id, Message = $"\"{habit.Name}\" is successfully added to your habits pool." });
            var regular = new ItalicTextMessageBuilder();
            messageComposer.ComposeMessageDelegate(regular)();
        }
    }
}
