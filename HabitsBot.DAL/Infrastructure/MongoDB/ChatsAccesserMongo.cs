using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using HabitsBot.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Infrastructure.MongoDB
{
    class ChatsAccesserMongo : IChatsAccesser
    {
        //private readonly IMongoCollection<Chat> _chatsCollection;
        private readonly DataAccesserMongo<Chat> _dataAccesserMongo;

        public ChatsAccesserMongo()
        {
            var config = ConfigHandler.GetJsonConfiguration();

            var connectionStrings = config.GetSection("connectionStrings");
            var connString = connectionStrings.GetSection("Mongo").Value;

            var mongoClient = new MongoClient(connString);

            //_chatsCollection = mongoClient.GetDatabase("HabitsDB").GetCollection<Chat>("ChatsCollection");

            _dataAccesserMongo = new DataAccesserMongo<Chat>("HabitsDB", "ChatsCollection");
        }

        public Chat AddChat(Chat model)
        {
            var modelToReturn = _dataAccesserMongo.AddItem(model);

            return modelToReturn;
        }

        public Chat DeleteChat(Chat model)
        {
            var deletedChat = _dataAccesserMongo.DeleteItem(model);

            return deletedChat;
        }

        public Chat DeleteChatOrNull(Chat model)
        {
            var deletedChat = _dataAccesserMongo.DeleteItemOrNull(model);

            return deletedChat;
        }

        public Chat EditChat(Chat model)
        {
            throw new NotImplementedException();
        }

        public Chat GetChat(Chat model)
        {
            var chat = _dataAccesserMongo.GetItem(model);

            return chat;
        }

        public Chat GetChatOrNull(Chat model)
        {
            var chat = _dataAccesserMongo.GetItemOrNull(model);

            return chat;
        }
    }
}
