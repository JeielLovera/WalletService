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
    public class WalletTransactionRepository : IWalletTransactionRepository
    {
        private readonly MongoDbContext _context;

        public WalletTransactionRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task CreateWalletTransaction(WalletTransaction walletTransaction)
        {
            await _context.walletTransactionCollection.InsertOneAsync(walletTransaction);
        }
    }
}
