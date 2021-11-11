using HabitsBot.Helpers;
using HabitsBot.TelegramCore.Infrastructure;
using HabitsBot.TelegramCore.Interfaces;
using HabitsBot.TelegramCore.Models;
using HabitsBot.TelegramCore.States;
using System;

namespace HabitsBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Host<Startup>.Run();           

            Console.ReadLine();
        }
    }
}
