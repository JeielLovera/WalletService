using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Entities;

namespace WalletService.Persistence.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task CreateWallet(Wallet wallet);
        Task<Wallet?> FindWalletByWalletId(string walletId);

        /// <summary>
        /// Update a single document.
        /// </summary>
        /// <param name="wallet">The wallet to replace.</param>
        /// <returns>
        /// Void.
        /// </returns>
        Task UpdateWallet(Wallet wallet);

        Task<IEnumerable<Wallet>> GetWalletsByUserId(string userId);
    }
}
