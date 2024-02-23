using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastBusiness.Services.LogService
{
    public interface IWebRequestLogService<T>
    {
        public Task LogRequest(T location);
    }
}
