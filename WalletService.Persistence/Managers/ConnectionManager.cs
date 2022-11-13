using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Persistence.Managers
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConfiguration _configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string MongoDbConnectionString => _configuration["MongoDBSettings:ServerConnection"];

        public string MongoDbName => _configuration["MongoDBSettings:DatabaseName"];
    }
}
