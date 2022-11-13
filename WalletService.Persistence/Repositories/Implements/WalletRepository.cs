using MongoDB.Driver;
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
    public class WalletRepository : IWalletRepository
    {
        private readonly MongoDbContext _context;

        public WalletRepository(MongoDbContext context)
        {
            _context = context;
        }


        public async Task CreateWallet(Wallet wallet)
        {
            await _context.walletCollection.InsertOneAsync(wallet);
        }

        public async Task<Wallet?> FindWalletByWalletId(string walletId)
        {
            var filter = Builders<Wallet>.Filter.Eq(x => x.WalletId, walletId);
            var wallet = (await _context.walletCollection.FindAsync(filter)).SingleOrDefault();
            return wallet;
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserId(string userId)
        {
            var filter = Builders<Wallet>.Filter.Eq(x => x.UserId, userId);
            var wallets = (await _context.walletCollection.FindAsync(filter)).ToEnumerable();
            return wallets;
        }

        public async Task UpdateWallet(Wallet wallet)
        {
            var filter = Builders<Wallet>.Filter.Eq(x => x.WalletId, wallet.WalletId);
            await _context.walletCollection.ReplaceOneAsync(filter, wallet);
        }
    }
}
