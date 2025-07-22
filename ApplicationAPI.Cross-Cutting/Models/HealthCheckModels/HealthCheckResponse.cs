using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Cross_Cutting.Models.HealthCheckModels
{
    public class HealthCheckResponse
    {
        public IEnumerable<HealthCheckEndPoint> HealthChecks { get; set; }
        public string HealthCheckDuration { get; set; }
    }
}
