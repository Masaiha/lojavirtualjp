using FM.lojavirtual.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.WebApi.Controllers
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
        private readonly ILojaRepository _lojaReposiroty;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILojaRepository lojaRepository)
        {
            _logger = logger;
            _lojaReposiroty = lojaRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ListarLojas")]
        public IActionResult ListarLojas()
        {
            try
            {
                var teste = _lojaReposiroty.ListarLojas();

                return Ok(teste);
            }
            catch (Exception)
            {
                return BadRequest("Ops, algo deu errado!");
            }
        }
    }
}