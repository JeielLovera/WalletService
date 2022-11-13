using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Entities;

namespace WalletService.Persistence.Repositories.Interfaces
{
    public interface IVisitorRepository
    {
        Task CreateVisitor(Visitor visitor);
    }
}
