using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Application.Contracts.DTO
{
    public class HealthCheckResponseDTO
    {
        public IEnumerable<HealthCheckEndPointDTO> HealthChecks { get; set; }
        public string HealthCheckDuration { get; set; }
    }
}
