using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastData.Model
{
    public class WebRequestLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
