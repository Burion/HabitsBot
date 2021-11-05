using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace HabitsBot.DAL.Infrastructure
{
    public class DataAccesser
    {
        private readonly IConfigurationRoot _config;
        public DataAccesser() 
        {
            _config = ConfigHandler.GetJsonConfigurationFromPath("appSettings.json");
        }

        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_config.GetSection("connectionString").Value))
            {
                var result = dbConnection.Query<T>(query);
                
                return result;
            }
        }

        public void ExecuteQuery(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_config.GetSection("connectionString").Value))
            {
                var result = dbConnection.Query(query);
            }
        }
    }
}
