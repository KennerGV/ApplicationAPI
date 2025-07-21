using ApplicationAPI.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Business.Contracts.Business
{
    public interface IBusinessAPI
    {
        Task<IEnumerable<WeatherForecast>> GetWeather();
    }
}
