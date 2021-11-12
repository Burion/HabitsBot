using HabitsBot.DAL.Models;
using HabitsBot.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitsBot.DAL.Infrastructure.MongoDB
{
    public class DataAccesserMongo<T> where T: MongoBaseModel
    {
        public IMongoCollection<T> itemsCollection;

        public DataAccesserMongo(string databaseName, string collectionName)
        {
            var config = ConfigHandler.GetJsonConfiguration();

            var connectionStrings = config.GetSection("connectionStrings");
            var connString = connectionStrings.GetSection("Mongo").Value;

            var mongoClient = new MongoClient(connString);

            itemsCollection = mongoClient.GetDatabase(databaseName).GetCollection<T>(collectionName);
        }

        public T AddItem(T model)
        {
            itemsCollection.InsertOne(model);

            return model;
        }

        public T DeleteItem(T model)
        {
            var items = itemsCollection.Find(h => h.Id == model.Id).ToList();
            itemsCollection.DeleteOne(h => h.Id == model.Id);

            return items.First();
        }

        public T DeleteItemOrNull(T model)
        {
            var items = itemsCollection.Find(h => h.Id == model.Id).ToList();
            itemsCollection.DeleteOne(h => h.Id == model.Id);

            return items.Count() > 0 ? items.First() : null;
        }

        public T EditItem(T model)
        {
            itemsCollection.ReplaceOne(c => c.Id == model.Id, model);

            var items = itemsCollection.Find(h => h.Id == model.Id).ToList();

            return items.Count() > 0 ? items.First() : null;
        }

        public T GetItem(T model)
        {
            var items = itemsCollection.Find(h => h.Id == model.Id).ToList();

            return items.First();
        }

        public T GetItemOrNull(T model)
        {
            var items = itemsCollection.Find(h => h.Id == model.Id).ToList();

            return items.Count() > 0 ? items.First() : null;
        }
    }
}
