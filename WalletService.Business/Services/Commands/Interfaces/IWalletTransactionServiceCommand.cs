using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Business.Services.Commands.Interfaces
{
    public interface IWalletTransactionServiceCommand
    {
        Task<WalletDTO?> ExcuteTransaction(TransactionDTO transaction);
    }
}
