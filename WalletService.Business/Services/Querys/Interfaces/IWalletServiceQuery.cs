using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Business.Services.Querys.Interfaces
{
    public interface IWalletServiceQuery
    {
        Task<IEnumerable<WalletDTO>> GetWalletsByUserId(string userId);
    }
}
