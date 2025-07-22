using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Business.Contracts.Business
{
    public interface IHealthCheckBusiness
    {
        Task<HealthCheckResponse> ObtenerEstadoAsync();
    }
}
