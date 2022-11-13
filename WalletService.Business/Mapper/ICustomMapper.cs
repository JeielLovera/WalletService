using WalletService.Domain.Entities;
using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Business.Mapper
{
    public interface ICustomMapper
    {
        Wallet ToWallet(CreateWalletDTO createWallet);
        WalletDTO ToWalletDTO(Wallet wallet);
        IEnumerable<WalletDTO> ToWalletDTO(IEnumerable<Wallet> wallets);
        WalletTransaction ToWalletTransaction(TransactionDTO transaction);

    }
}
