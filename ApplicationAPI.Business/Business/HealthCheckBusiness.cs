using ApplicationAPI.Business.Contracts.Business;
using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Business.Business
{
    public class HealthCheckBusiness : IHealthCheckBusiness
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthCheckBusiness(HealthCheckService healthCheckService) { 
            _healthCheckService = healthCheckService;
        }

        public async Task<HealthCheckResponse> ObtenerEstadoAsync()
        {
            var report =  await _healthCheckService.CheckHealthAsync();

            return new HealthCheckResponse
            {
                HealthChecks = report.Entries.Select(x => new HealthCheckEndPoint
                {
                    Component = x.Key,
                    Status = x.Value.Status.ToString(),
                    Description = x.Value.Description,
                    Duration = x.Value.Duration.ToString()
                }),
                HealthCheckDuration = report.TotalDuration.ToString()
            };
        }
    }
}
