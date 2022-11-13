using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Entities;
using WalletService.Persistence.Managers;

namespace WalletService.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private readonly IConnectionManager _manager;

        public MongoDbContext(IConnectionManager manager)
        {
            _manager = manager;
            _client = new MongoClient(_manager.MongoDbConnectionString);
            _db = _client.GetDatabase(_manager.MongoDbName);

            visitorCollection = _db.GetCollection<Visitor>("visitor");
            walletCollection = _db.GetCollection<Wallet>("wallet");
            walletLogCollection = _db.GetCollection<WalletLog>("walletLog");
            walletTransactionCollection = _db.GetCollection<WalletTransaction>("walletTransaction");
        }

        public IMongoCollection<Visitor> visitorCollection;
        public IMongoCollection<Wallet> walletCollection;
        public IMongoCollection<WalletLog> walletLogCollection;
        public IMongoCollection<WalletTransaction> walletTransactionCollection;

    }
}
