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
    public class VisitorRepository : IVisitorRepository
    {
        private readonly MongoDbContext _context;

        public VisitorRepository(MongoDbContext context)
        {
            _context = context;
        }


        public async Task CreateVisitor(Visitor visitor)
        {
            await _context.visitorCollection.InsertOneAsync(visitor);
        }
    }
}
