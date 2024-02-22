using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastData.Model;

namespace WeatherForecastBusiness.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
       
        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("NWSWeatherLibraryForDotNet/1.0");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("https://api.weather.gov");
        }

        public async Task<ForecastResponse> GetForecastAsync(decimal lat, decimal lng)
        {
            //Get the gridpoint information for the given latitude and longitude.
            var redirectResponseText = await _httpClient.GetAsync($"https://api.weather.gov/points/{lat.ToString("0.####")},{lng.ToString("0.####")}");
            var cd= await redirectResponseText.Content.ReadAsStringAsync();
            //Parse the json response
      
            dynamic json = JObject.Parse(cd);

            var city = json.properties.relativeLocation.properties.city.Value;
            var state = json.properties.relativeLocation.properties.state.Value;
            //Get the forecast Url from the response
            var forecastUrl = (string)json.properties.forecast;

            //Load the forecast Url
            var forecastResponseText = await _httpClient.GetAsync(forecastUrl);

            //Parse the json response
            dynamic json2 = JObject.Parse(await forecastResponseText.Content.ReadAsStringAsync());

            //Instantiate a new ForecastResponse object and fill it with the data received
            var response = new ForecastResponse()
            {
                Periods = new List<ForecastPeriod>(),
                ElevationInMeters = json2.properties.elevation.value,
                LastUpdatedDate = json2.properties.updated,
                Latitude = lat,
                Longitude = lng
            };

            foreach (dynamic p in json2.properties.periods)
            {
                response.Periods.Add(new ForecastPeriod()
                {
                    Name = p.name,
                    StartTime = p.startTime,
                    EndTime = p.endTime,
                    IsDayTime = p.isDaytime,
                    TemperatureInFahrenheit = p.temperature,
                    WindSpeed = p.windSpeed,
                    WindDirection = p.windDirection,
                    ForecastShort = p.shortForecast,
                    ForecastLong = p.detailedForecast
                });
            }

            response.RawData = await forecastResponseText.Content.ReadAsStringAsync();

            return response;
        }



       
    }

   
}
