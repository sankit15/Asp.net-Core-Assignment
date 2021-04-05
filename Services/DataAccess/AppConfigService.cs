using IServices.IDataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DataAccess
{

    public class AppConfigService : IAppConfigService
    {
        private readonly IConfiguration _config;
        public string ConnectionString { get; }
      
      
        public AppConfigService(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("constr");
           
           
        }
    }
}
