using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastData.Model
{
    public class WeatherForecast
    {
        // Define properties according to the structure of the forecast JSON
        // For example:
        public string temperature { get; set; }
        public string description { get; set; }
        public string humidity { get; set; }


        // You need to define properties based on the actual structure of the forecast JSON.
        // You can use tools like https://json2csharp.com/ to generate C# classes from JSON.
    }
}
