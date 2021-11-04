using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Models
{
    public class Habit
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public override bool Equals(object obj)
        {
            var habitToCompare = (Habit)obj;

            return habitToCompare.Name == Name && habitToCompare.UserId == UserId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, UserId);
        }
    }
}
