using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Data;
using WeatherForecastBusiness.Services;
using WeatherForecastBusiness.Services.LogService;
using WeatherForecastBusiness.Services.WeatherServices;
using WeatherForecastData.Model;

namespace WeatherForeCastAPP.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly IWebRequestLogService<WebRequestLog> _webRequestLogService;

        public WeatherController(IWeatherService weatherService, IWebRequestLogService<WebRequestLog> webRequestLogService)
        {
            _weatherService = weatherService;
            _webRequestLogService = webRequestLogService;
        }

        public IActionResult Index()
        {
            // Return view to display weather data form
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherForecast([FromBody] Location location)
        {
            try
            {
               
                var forecast = await _weatherService.GetForecastAsync(location.Latitude, location.Longitude);

                WebRequestLog log = new WebRequestLog
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.Now,
                };

                await _webRequestLogService.LogRequest(log);

                System.Diagnostics.Debug.WriteLine($"Received location: Latitude = {location.Latitude}, Longitude = {location.Longitude}");

                // Respond with a success message
                return Ok(new { message = "Location received successfully!", forecast });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                System.Diagnostics.Debug.WriteLine($"An error occurred: {ex.Message}");

                // Return an error response
                return StatusCode(500, new { message = "An error occurred while fetching the weather forecast." });
            }
        }



    }
}
