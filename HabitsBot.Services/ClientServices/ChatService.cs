using AutoMapper;
using HabitsBot.DAL.Infrastructure.MongoDB;
using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using HabitsBot.Services.Dtos;
using HabitsBot.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.Services.ClientServices
{
    public class ChatService : IChatService
    {
        private readonly IChatsAccesser _chatsAccesser;
        private readonly IMapper _mapper;
        
        public ChatService()
        {
            //TODO implement DI 
            _chatsAccesser = new ChatsAccesserMongo();
            var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ChatDto, Chat>();
                    cfg.CreateMap<Chat, ChatDto>();
                }
            );
            _mapper = new Mapper(mapperConfig);
        }

        public ChatDto AddChat(ChatDto chat)
        {
            var dbModel = _mapper.Map<ChatDto, Chat>(chat);
            var addedModel = _chatsAccesser.AddChat(dbModel);
            var modelToReturn = _mapper.Map<Chat, ChatDto>(addedModel);

            return modelToReturn;
        }

        public ChatDto DeleteChat(ChatDto chat)
        {
            throw new NotImplementedException();
        }

        public ChatDto EditChat(ChatDto chat)
        {
            var chatDbModel = _mapper.Map<ChatDto, Chat>(chat);
            var editedChat = _chatsAccesser.EditChat(chatDbModel);
            var chatToReturn = _mapper.Map<Chat, ChatDto>(editedChat);
            
            return chatToReturn;
        }

        public ChatDto GetChat(ChatDto chat)
        {
            throw new NotImplementedException();
        }

        public ChatDto GetChatById(string id)
        {
            var chatFindModel = new Chat()
            {
                Id = id
            };

            var dbModel = _chatsAccesser.GetChatOrNull(chatFindModel);
            var modelToReturn = _mapper.Map<Chat, ChatDto>(dbModel);

            return modelToReturn;
        }

        public ChatDto GetChatByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
