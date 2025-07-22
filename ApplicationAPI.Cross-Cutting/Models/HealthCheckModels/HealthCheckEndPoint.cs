using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Cross_Cutting.Models.HealthCheckModels
{
    public class HealthCheckEndPoint
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }
}
