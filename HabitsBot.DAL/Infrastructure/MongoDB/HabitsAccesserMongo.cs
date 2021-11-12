using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using HabitsBot.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HabitsBot.DAL.Infrastructure.MongoDB
{
    public class HabitsAccesserMongo : IHabitsAccesser
    {
        //IMongoCollection<Habit> habitsCollection;
        private readonly DataAccesserMongo<Habit> _dataAccesserMongo;

        public HabitsAccesserMongo()
        {
            var config = ConfigHandler.GetJsonConfiguration();

            var connectionStrings = config.GetSection("connectionStrings");
            var connString = connectionStrings.GetSection("Mongo").Value;

            var mongoClient = new MongoClient(connString);

            //habitsCollection = mongoClient.GetDatabase("HabitsDB").GetCollection<Habit>("HabitsCollection");
            _dataAccesserMongo = new DataAccesserMongo<Habit>("HabitsDB", "HabitsCollection");
        }

        public Habit AddHabit(Habit model)
        {
            var modelToReturn = _dataAccesserMongo.AddItem(model);

            return modelToReturn;
        }

        public Habit DeleteHabit(Habit model)
        {
            var deletedHabit = _dataAccesserMongo.DeleteItem(model);

            return deletedHabit;
        }

        public Habit DeleteHabitOrNull(Habit model)
        {
            var deletedHabit = _dataAccesserMongo.DeleteItemOrNull(model);

            return deletedHabit;
        }

        public Habit EditHabit(Habit model)
        {
            throw new NotImplementedException();
        }

        public Habit GetHabit(Habit model)
        {
            var habit = _dataAccesserMongo.GetItem(model);

            return habit;
        }
        public IEnumerable<Habit> GetHabits(Expression<Func<Habit, bool>> predicate)
        {
            var habits = _dataAccesserMongo.GetItems(predicate);

            return habits;
        }

        public Habit GetHabitOrNull(Habit model)
        {
            var habit = _dataAccesserMongo.GetItemOrNull(model);

            return habit;
        }

        public IEnumerable<Habit> GetHabits(Habit model)
        {
            throw new NotImplementedException();
        }
    }
}
