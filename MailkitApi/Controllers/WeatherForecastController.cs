using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailkitApi.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailkitApi.Controllers
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
        private readonly Imail _mailer;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Imail mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("export")]
        public async Task<IActionResult> ExportWeatherReport()
        {
            await _mailer.SendEmailAsync("mateus.seducsobral@gmail.com", "Weather Report","Detailed Report");
            return NoContent();
        }
    }
}
