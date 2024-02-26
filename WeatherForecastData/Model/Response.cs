using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastData.Model
{
    public class Response<T>
    {
        public T ResponseResult { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; } = true;
        
    }
}
