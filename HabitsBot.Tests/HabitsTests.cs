using HabitsBot.DAL;
using HabitsBot.DAL.Infrastructure;
using HabitsBot.DAL.Models;
using HabitsBot.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HabitsBot.Tests
{
    public class HabitsTests: IDisposable
    {
        private readonly DataAccesser dataAccesser;
        private const string userId = "USER_ID_1";
        private const string habitName = "USER_ID_1";

        public HabitsTests()
        {
            dataAccesser = new DataAccesser();
        }

        [Fact]
        public void AddingRecordTest()
        {
            var queryToInsert = $"INSERT INTO Habits (UserId, Name) VALUES ({userId.SingleQuotesShield()}, {habitName.SingleQuotesShield()})";
            dataAccesser.ExecuteQuery(queryToInsert);

            var queryToSelect = $"SELECT * FROM Habits WHERE Name={habitName.SingleQuotesShield()} AND UserId={userId.SingleQuotesShield()}";
            var habits = dataAccesser.ExecuteQuery<Habit>(queryToSelect);
            
            if (habits.Count() != 1)
            {
                Assert.True(false);
            }

            var correctHabit = new Habit() { Name = habitName, UserId = userId };
            Assert.Equal(habits.First(), correctHabit);
        }

        [Fact]
        public void EditingRecordTest()
        {
            var queryToInsert = $"INSERT INTO Habits (UserId, Name) VALUES ({userId.SingleQuotesShield()}, {habitName.SingleQuotesShield()})";
            dataAccesser.ExecuteQuery(queryToInsert);

            var queryToSelect = $"SELECT * FROM Habits WHERE Name={habitName.SingleQuotesShield()} AND UserId={userId.SingleQuotesShield()}";
            var habits = dataAccesser.ExecuteQuery<Habit>(queryToSelect);

            if (habits.Count() != 1)
            {
                Assert.True(false);
            }

            var correctHabit = new Habit() { Name = habitName, UserId = userId };
            Assert.Equal(habits.First(), correctHabit);
        }

        public void Dispose()
        {
            var queryToDelete = $"DELETE FROM Habits WHERE Name={habitName.SingleQuotesShield()} AND UserId={userId.SingleQuotesShield()}";
            dataAccesser.ExecuteQuery(queryToDelete);
        }
    }
}
