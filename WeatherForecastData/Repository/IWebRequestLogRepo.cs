using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastData.Repository
{
    internal interface IWebRequestLogRepo
    {
        public Task SaveWebRequestLog(WebRequestLog log);
    }
}
