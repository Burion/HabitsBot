using HabitsBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        IEnumerable<Habit> GetHabits(Habit model);
        IEnumerable<Habit> GetHabits(Expression<Func<Habit, bool>> predicate);
        Habit GetHabitOrNull(Habit model);
    }
}
