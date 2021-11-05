﻿using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HabitsBot.DAL.Exceptions;
using HabitsBot.Tests.Helpers;

namespace HabitsBot.DAL.Infrastructure
{
    public class HabitsAccesser : IHabitsAccesser
    {
        private readonly DataAccesser _dataAccesser;

        public HabitsAccesser()
        {
            _dataAccesser = new DataAccesser();
        }

        public Habit AddHabit(Habit model)
        {
            var queryToInsert = $"INSERT INTO Habits (UserId, Name) VALUES ({model.UserId.SingleQuotesShield()}, {model.UserId.SingleQuotesShield()})";
            _dataAccesser.ExecuteQuery(queryToInsert);

            var queryToSelect = $"SELECT * FROM Habits WHERE Name={model.Name.SingleQuotesShield()} AND UserId={model.UserId.SingleQuotesShield()}";
            var habits = _dataAccesser.ExecuteQuery<Habit>(queryToSelect);

            if(habits.Count() != 1)
            {
                throw new InvalidQueryException();
            }

            return habits.First();
        }

        public Habit DeleteHabit(Habit model)
        {
            var queryToSelect = $"SELECT * FROM Habits WHERE Name={model.Name.SingleQuotesShield()} AND UserId={model.UserId.SingleQuotesShield()}";
            var habits = _dataAccesser.ExecuteQuery<Habit>(queryToSelect);
            
            if (habits.Count() != 1)
            {
                throw new InvalidQueryException();
            }

            var queryToDelete = $"DELETE FROM Habits WHERE Name={model.Name.SingleQuotesShield()} AND UserId={model.UserId.SingleQuotesShield()}";
            _dataAccesser.ExecuteQuery(queryToDelete);

            return habits.First();
        }

        public Habit EditHabit(Habit model)
        {
            throw new NotImplementedException();
        }

        public Habit GetHabit(Habit model)
        {
            var queryToSelect = $"SELECT * FROM Habits WHERE Name={model.Name.SingleQuotesShield()} AND UserId={model.UserId.SingleQuotesShield()}";
            var habits = _dataAccesser.ExecuteQuery<Habit>(queryToSelect);

            if (habits.Count() != 1)
            {
                throw new InvalidQueryException();
            }

            return habits.First();
        }
    }
}
