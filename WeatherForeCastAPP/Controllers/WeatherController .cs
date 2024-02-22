using Microsoft.AspNetCore.Mvc;
using WeatherForecastBusiness.Services;
using WeatherForecastData.Model;

namespace WeatherForeCastAPP.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            // Return view to display weather data form
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherForecast([FromBody] Location location)
        {
            var forecast = await _weatherService.GetForecastAsync(location.Latitude, location.Longitude);

            System.Diagnostics.Debug.WriteLine($"Received location: Latitude = {location.Latitude}, Longitude = {location.Longitude}");

            // Respond with a success message
            return Ok(new { message = "Location received successfully!", forecast });
        }
    }
}
