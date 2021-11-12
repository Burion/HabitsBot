using HabitsBot.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Services.Interfaces
{
    public interface IHabitsService
    {
        HabitDto AddHabit(HabitDto habit);
        HabitDto DeleteHabit(HabitDto habit);
        HabitDto EditHabit(HabitDto habit);
        HabitDto GetHabitById(string id);
        IEnumerable<HabitDto> GetHabitsForChat(string chatId);
    }
}
