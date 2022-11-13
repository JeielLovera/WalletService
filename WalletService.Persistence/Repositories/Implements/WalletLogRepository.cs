using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Entities;
using WalletService.Persistence.Context;
using WalletService.Persistence.Repositories.Interfaces;

namespace WalletService.Persistence.Repositories.Implements
{
    public class WalletLogRepository : IWalletLogRepository
    {
        private readonly MongoDbContext _context;

        public WalletLogRepository(MongoDbContext context)
        {
            _context = context;
        }


        public async Task CreateWalletLog(WalletLog walletLog)
        {
            await _context.walletLogCollection.InsertOneAsync(walletLog);
        }
    }
}
