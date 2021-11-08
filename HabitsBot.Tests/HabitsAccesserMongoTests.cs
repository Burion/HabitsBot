using HabitsBot.DAL.Infrastructure;
using HabitsBot.DAL.Infrastructure.MongoDB;
using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HabitsBot.Tests
{
    public class HabitsAccesserMongoTests : IDisposable
    {
        private readonly IHabitsAccesser _habitsAccesser;
        private const string userId = "USER_ID_1";
        private const string habitName = "HABIT_ID_1";

        private const string userIdEdited = "USER_ID_2";
        private const string habitNameEdited = "USER_ID_2";
        readonly Habit model;

        public HabitsAccesserMongoTests()
        {
            _habitsAccesser = new HabitsAccesserMongo();
            model = new Habit() { Name = habitName, UserId = userId };
        }

        [Fact]
        public void HabitsAccesserAddingTest()
        {
            var habit = _habitsAccesser.AddHabit(model);

            Assert.Equal(habit, model);
        }

        [Fact]
        public void HabitsAccesserDeletingTest()
        {
            _habitsAccesser.AddHabit(model);
            var deletedHabit = _habitsAccesser.DeleteHabit(model);

            var habit = _habitsAccesser.GetHabitOrNull(model);
            
            if(habit != null)
            {
                Assert.True(false, "Item is not deleted");
            }

            Assert.Equal(deletedHabit, model);
        }

        public void Dispose()
        {
            _habitsAccesser.DeleteHabitOrNull(model);
        }
    }
}
