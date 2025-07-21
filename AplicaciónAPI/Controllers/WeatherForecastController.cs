using ApplicationAPI.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AplicaciónAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceAPI _service;

        public WeatherForecastController(IServiceAPI service)
        {
            _service = service;
        }

        [Produces("application/json")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetWeatherForecast());
        }
    }
}
