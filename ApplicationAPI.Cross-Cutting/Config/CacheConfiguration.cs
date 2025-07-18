using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAPI.Cross_Cutting.Config
{
    public class CacheConfiguration
    {
        public int CacheTech { get; set; }
        public string Endpoint { get; set; }
        public string Key { get; set; }
        public double AbsoluteExpiration { get; set; }
        public double SlidingExpiration { get; set; }
        public int AsyncTimeout { get; set; }
        public int ConnectRetry { get; set; }
        public int ConnectTimeout { get; set; }
        public int DefaultDatabase { get; set; }
        public string InstanceName { get; set; }
        public int Port { get; set; }
    }
}
