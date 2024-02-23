using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastBusiness.Services.LogService
{
    public class WebRequestLogService : IWebRequestLogService<WebRequestLog>
    {
        public Task LogRequest(WebRequestLog location)
        {
            throw new NotImplementedException();
        }
    }
}
