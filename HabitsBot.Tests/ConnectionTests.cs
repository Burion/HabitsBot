using HabitsBot.DAL;
using HabitsBot.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HabitsBot.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public void VerifyConnection()
        {
            ConfigHandler.GetJsonConfigurationFromPath("appSettings.json");

            var dataAccesser = new DataAccesser();

            dataAccesser.ExecuteQuery("SELECT * FROM Habits");
        }


    }
}
