using HabitsBot.DAL.Models;
using HabitsBot.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Services.Interfaces
{
    public interface IChatService
    {
        ChatDto AddChat(ChatDto chat);
        ChatDto DeleteChat(ChatDto chat);
        ChatDto EditChat(ChatDto chat);
        ChatDto GetChat(ChatDto chat);
        ChatDto GetChatById(string id);
        ChatDto GetChatByUserId(string id);

    }
}
