﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Persistence.Managers
{
    public interface IConnectionManager
    {
        string MongoDbConnectionString { get; }
        string MongoDbName { get; }
    }
}
