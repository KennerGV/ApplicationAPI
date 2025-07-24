using ApplicationAPI.Application.Contracts.DTO;
using ApplicationAPI.Application.Contracts.Services;
using ApplicationAPI.Business.Contracts.Business;
using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Application.Services
{
    public class HealthCheckServices : IHealthCheckServices
    {
        private readonly IHealthCheckBusiness _businessAPI;
        private readonly IMapper _mapper;

        public HealthCheckServices(IHealthCheckBusiness businessAPI, IMapper mapper)
        {
            _businessAPI = businessAPI;
            _mapper = mapper;
        }

        public Task<HealthCheckResponse> GetHealth()
        {
            
            var healthResponse = _businessAPI.ObtenerEstadoAsync();

            return healthResponse;
        }
    }
}
