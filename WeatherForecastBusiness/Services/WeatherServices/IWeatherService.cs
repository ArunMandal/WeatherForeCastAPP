using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastBusiness.Services.WeatherServices
{
    public interface IWeatherService
    {
        public  Task<Response< ForecastResponse>> GetForecastAsync(decimal lat, decimal lng);
    }
}
