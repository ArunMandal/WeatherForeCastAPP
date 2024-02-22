using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastBusiness.Services;
using WeatherForecastData.Model;

namespace WeatherForeCastAPP.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLocationAsync([FromBody] Location location)
        {

           // var weatherData = await _weatherService.GetWeatherForecast(location.Latitude, location.Longitude);
            var forecast = await _weatherService.GetForecastAsync(location.Latitude, location.Longitude);
            //var weatherData = await _weatherService.GetWeatherForecast(Math.Round(location.Latitude, 3), Math.Round(location.Longitude, 3));
            // Log the received location, replace this with your own logic (e.g., saving to a database)
            System.Diagnostics.Debug.WriteLine($"Received location: Latitude = {location.Latitude}, Longitude = {location.Longitude}");

            // Respond with a success message
            return Ok(new { message = "Location received successfully!" });
        }



    }
}
