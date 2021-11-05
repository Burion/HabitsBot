using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using HabitsBot.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitsBot.DAL.Infrastructure.MongoDB
{
    public class HabitsAccesserMongo : IHabitsAccesser
    {
        IMongoCollection<Habit> habitsCollection;

        public HabitsAccesserMongo()
        {
            var config = ConfigHandler.GetJsonConfiguration();

            var connectionStrings = config.GetSection("connectionStrings");
            var connString = connectionStrings.GetSection("Mongo").Value;

            var mongoClient = new MongoClient(connString);

            habitsCollection = mongoClient.GetDatabase("HabitsDB").GetCollection<Habit>("HabitsCollection");
        }
        public Habit AddHabit(Habit model)
        {
            habitsCollection.InsertOne(model);

            return model;
        }

        public Habit DeleteHabit(Habit model)
        {
            var habits = habitsCollection.Find(h => h.Id == model.Id).ToList();
            habitsCollection.DeleteOne(h => h.Id == model.Id);

            return habits.First();
        }

        public Habit DeleteHabitOrNull(Habit model)
        {
            var habits = habitsCollection.Find(h => h.Id == model.Id).ToList();
            habitsCollection.DeleteOne(h => h.Id == model.Id);

            return habits.Count() > 0 ? habits.First() : null;
        }

        public Habit EditHabit(Habit model)
        {
            throw new NotImplementedException();
        }

        public Habit GetHabit(Habit model)
        {
            var habits = habitsCollection.Find(h => h.Id == model.Id).ToList();

            return habits.First();
        }

        public Habit GetHabitOrNull(Habit model)
        {
            var habits = habitsCollection.Find(h => h.Id == model.Id).ToList();

            return habits.Count() > 0 ? habits.First() : null;
        }
    }
}
