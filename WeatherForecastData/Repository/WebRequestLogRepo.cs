using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.ConnectionString;
using WeatherForecastData.Model;

namespace WeatherForecastData.Repository
{
    public class WebRequestLogRepo : IWebRequestLogRepo
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public WebRequestLogRepo(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }


        public async Task SaveWebRequestLog(WebRequestLog log)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_connectionStringProvider.GetConnectionString()))
                {
                    // Open the connection
                    dbConnection.Open();

                    // Insert log entry into the database
                    var sql = @"INSERT INTO WebRequestLog (Timestamp, Latitude, Longitude) VALUES (@Timestamp, @Latitude, @Longitude)";
                    await dbConnection.ExecuteAsync(sql, log);
                }
            }
            catch (Exception ex)
            {

            }



           
        }
    }
}
