using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastData.Repository
{
    internal class WebRequestLogRepo : IWebRequestLogRepo
    {
        public async Task SaveWebRequestLog(WebRequestLog log)
        {


            using (IDbConnection dbConnection = new SqlConnection("YourConnectionString"))
            {
                // Open the connection
                dbConnection.Open();

                // Insert log entry into the database
                var sql = @"INSERT INTO LogEntries (Timestamp, Latitude, Longitude) VALUES (@Timestamp, @Latitude, @Longitude)";
                await dbConnection.ExecuteAsync(sql, log);
            }

            throw new NotImplementedException();
        }
    }
}
