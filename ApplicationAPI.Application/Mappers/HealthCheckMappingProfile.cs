using ApplicationAPI.Application.Contracts.DTO;
using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using ApplicationAPI.DataAccess.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Application.Mappers
{
    public class HealthCheckMappingProfile : Profile
    {
        public HealthCheckMappingProfile() 
        {
            CreateMap<HealthCheckEndPoint, HealthCheckEndPointDTO>()
                .ReverseMap();
        }
    }
}
