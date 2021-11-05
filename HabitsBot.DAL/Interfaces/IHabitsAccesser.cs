using HabitsBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Interfaces
{
    public interface IHabitsAccesser
    {
        Habit AddHabit(Habit model);
        Habit DeleteHabit(Habit model);
        Habit DeleteHabitOrNull(Habit model);
        Habit EditHabit(Habit model);
        Habit GetHabit(Habit model);
        Habit GetHabitOrNull(Habit model);
    }
}
