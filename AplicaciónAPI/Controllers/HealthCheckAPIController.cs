using ApplicationAPI.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AplicaciónAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckAPIController : ControllerBase
    {   private readonly IHealthCheckServices _health;

        public HealthCheckAPIController(IHealthCheckServices health)
        {
            _health = health;
        }

        [HttpGet("/Health")]
        public async Task<IActionResult> GetHealthChecks()
        {
            var report = await _health.GetHealth();

            return Ok(report);
        }

    }
}
