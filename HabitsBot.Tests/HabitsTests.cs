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

        private const string userIdEdited = "USER_ID_2";
        private const string habitNameEdited = "USER_ID_2";

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

            var correctHabit = new Habit() { Name = habitName, ChatId = userId };
            Assert.Equal(habits.First(), correctHabit);
        }

        [Fact]
        public void EditingRecordTest()
        {
            var queryToInsert = $"INSERT INTO Habits (UserId, Name) VALUES ({userId.SingleQuotesShield()}, {habitName.SingleQuotesShield()})";
            dataAccesser.ExecuteQuery(queryToInsert);
            
            var queryToEdit = $"UPDATE Habits SET Name={habitNameEdited.SingleQuotesShield()}, UserId={userIdEdited.SingleQuotesShield()} WHERE Name={habitName.SingleQuotesShield()} AND UserId={userId.SingleQuotesShield()}";
            dataAccesser.ExecuteQuery(queryToEdit);

            var queryToSelect = $"SELECT * FROM Habits WHERE Name={habitNameEdited.SingleQuotesShield()} AND UserId={userIdEdited.SingleQuotesShield()}";
            var habits = dataAccesser.ExecuteQuery<Habit>(queryToSelect);

            if (habits.Count() != 1)
            {
                Assert.True(false);
            }

            var correctHabit = new Habit() { Name = habitNameEdited, ChatId = userIdEdited };
            Assert.Equal(habits.First(), correctHabit);
        }

        public void Dispose()
        {
            var queryToEdit = $"UPDATE Habits SET Name={habitName.SingleQuotesShield()}, UserId={userId.SingleQuotesShield()} WHERE Name={habitNameEdited.SingleQuotesShield()} AND UserId={userIdEdited.SingleQuotesShield()}";
            dataAccesser.ExecuteQuery(queryToEdit);

            var queryToDelete = $"DELETE FROM Habits WHERE Name={habitName.SingleQuotesShield()} AND UserId={userId.SingleQuotesShield()}";
            dataAccesser.ExecuteQuery(queryToDelete);
        }
    }
}
