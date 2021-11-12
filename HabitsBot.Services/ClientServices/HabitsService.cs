using AutoMapper;
using HabitsBot.DAL.Infrastructure.MongoDB;
using HabitsBot.DAL.Interfaces;
using HabitsBot.DAL.Models;
using HabitsBot.Services.Dtos;
using HabitsBot.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HabitsBot.Services.ClientServices
{
    public class HabitsService : IHabitsService
    {
        private readonly IHabitsAccesser _habitsAccesser;
        private readonly IMapper _mapper;

        public HabitsService()
        {
            //TODO implement DI 
            _habitsAccesser = new HabitsAccesserMongo();
            var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<HabitDto, Habit>();
                    cfg.CreateMap<Habit, HabitDto>();
                }
            );
            _mapper = new Mapper(mapperConfig);
        }

        public HabitDto AddHabit(HabitDto habit)
        {
            var dbModel = _mapper.Map<HabitDto, Habit>(habit);

            var addedModel = _habitsAccesser.AddHabit(dbModel);
            var modelToReturn = _mapper.Map<Habit, HabitDto>(addedModel);

            return modelToReturn;
        }

        public HabitDto DeleteHabit(HabitDto habit)
        {
            throw new NotImplementedException();
        }

        public HabitDto EditHabit(HabitDto habit)
        {
            throw new NotImplementedException();
        }

        public HabitDto GetHabitById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HabitDto> GetHabitsForChat(string chatId)
        {
            var habit = new Habit()
            {
                ChatId = chatId
            };

            Expression<Func<Habit, bool>> predicate = h => h.ChatId == chatId;
            //Predicate<Habit> predicate = h => h.ChatId == chatId;

            var models = _habitsAccesser.GetHabits(predicate);
            var modelsToReturn = _mapper.Map<IEnumerable<Habit>, IEnumerable<HabitDto>>(models);

            return modelsToReturn;
        }
    }
}
