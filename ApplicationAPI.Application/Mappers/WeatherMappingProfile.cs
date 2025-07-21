using ApplicationAPI.Application.Contracts.DTO;
using ApplicationAPI.DataAccess.Contracts;
using AutoMapper;

namespace ApplicationAPI.Application.Mappers
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile() 
        {
            CreateMap<WeatherForecast, WeatherForecastDTO>()
                .ReverseMap();
        }
    }
}
