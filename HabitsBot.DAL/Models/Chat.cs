using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot.DAL.Models
{
    public class Chat : MongoBaseModel
    {
        public int State { get; set; }
        public string UserId { get; set; }
    }
}
