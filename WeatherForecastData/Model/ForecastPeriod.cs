using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastData.Model
{
    public class ForecastPeriod
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDayTime { get; set; }
        public decimal TemperatureInFahrenheit { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string ForecastShort { get; set; }
        public string ForecastLong { get; set; }
    }
}
