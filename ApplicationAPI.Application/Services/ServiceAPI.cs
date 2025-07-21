using ApplicationAPI.Application.Contracts.DTO;
using ApplicationAPI.Application.Contracts.Services;
using ApplicationAPI.Business.Contracts.Business;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Application.Services
{
    public class ServiceAPI : IServiceAPI
    {
        private readonly IBusinessAPI _business;
        private readonly IMapper _mapper;
        public ServiceAPI(IBusinessAPI business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecast()
        {
            var responseEntity = await _business.GetWeather();
            var response = new List<WeatherForecastDTO>();

            response = _mapper.Map<List<WeatherForecastDTO>>(responseEntity);

            return response;
        }
    }
}
