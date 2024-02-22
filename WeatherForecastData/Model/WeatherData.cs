using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastData.Model
{
    public class WeatherData
    {
        public string Time { get; set; }
        public string Forecast { get; set; }

        public Properties properties { get; set; }
        // Add more properties as needed to represent weather data
    }
}
