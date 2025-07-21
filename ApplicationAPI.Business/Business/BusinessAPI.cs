using ApplicationAPI.Business.Contracts.Business;
using ApplicationAPI.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Business.Business
{
    
    public class BusinessAPI : IBusinessAPI
    {
        private readonly string[] Summaries= new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            var weatherResult = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {

                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return await Task.FromResult<IEnumerable<WeatherForecast>>(weatherResult);
        }
    }
}
