using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;
using HabitsBot.Helpers;

namespace HabitsBot.DAL.Infrastructure
{
    public class DataAccesser
    {
        private readonly IConfigurationRoot _config;
        private readonly string _connectionString;
        public DataAccesser() 
        {
            _config = ConfigHandler.GetJsonConfigurationFromPath("appSettings.json");
            var connectionStrings = _config.GetSection("connectionStrings");
            var connString = connectionStrings.GetSection("SQLServer").Value;

            _connectionString = connString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var result = dbConnection.Query<T>(query);
                
                return result;
            }
        }

        public void ExecuteQuery(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var result = dbConnection.Query(query);
            }
        }
    }
}
