using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Models
{
    public class Habit : MongoBaseModel
    {
        public string Name { get; set; }
        public string ChatId { get; set; }

        public override bool Equals(object obj)
        {
            var habitToCompare = (Habit)obj;

            return habitToCompare.Name == Name && habitToCompare.ChatId == ChatId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ChatId);
        }
    }
}
