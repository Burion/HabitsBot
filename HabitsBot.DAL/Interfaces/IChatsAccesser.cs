using HabitsBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Interfaces
{
    interface IChatsAccesser
    {
        Chat AddChat(Chat model);
        Chat DeleteChat(Chat model);
        Chat DeleteChatOrNull(Chat model);
        Chat EditChat(Chat model);
        Chat GetChat(Chat model);
        Chat GetChatOrNull(Chat model);
    }
}
