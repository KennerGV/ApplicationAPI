using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationAPI.Application.Contracts.DTO;

namespace ApplicationAPI.Application.Contracts.Services
{
    public interface IServiceAPI
    {
        Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecast();
    }
}
