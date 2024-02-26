using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;
using WeatherForecastData.Repository;

namespace WeatherForecastBusiness.Services.LogService
{
    public class WebRequestLogService : IWebRequestLogService<WebRequestLog>
    {
        private readonly IWebRequestLogRepo _webRequestLogRepo;
        public WebRequestLogService(IWebRequestLogRepo webRequestLogRepo) {
            _webRequestLogRepo= webRequestLogRepo;
        }
        public async Task LogRequest(WebRequestLog location)
        {

          await  _webRequestLogRepo.SaveWebRequestLog(location);
           
        }
    }
}
