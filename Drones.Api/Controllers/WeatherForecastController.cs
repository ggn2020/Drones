using Drones.Application.Common.Models;
using Drones.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drones.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDroneService _droneService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDroneService droneService)
        {
            _logger = logger;
            _droneService = droneService;
        }

        [HttpGet(nameof(GetAvailable))]
        public async Task<ActionResult<IEnumerable<DroneDto>>> GetAvailable()
        {
            var result = await _droneService.GetAvailable();
            return Ok(result);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}