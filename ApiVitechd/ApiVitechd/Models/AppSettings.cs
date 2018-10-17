using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVitechd.Models
{
    public class AppSettings
    {
        public string ApiServer { get; set; }
        public AppSettings(string apiServer)
        {
            this.ApiServer = apiServer;
        }
    }
    
}
