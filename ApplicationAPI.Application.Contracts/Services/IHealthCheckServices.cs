using ApplicationAPI.Application.Contracts.DTO;
using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Application.Contracts.Services
{
    public interface IHealthCheckServices
    {
        Task<HealthCheckResponse> GetHealth();
    }
}
