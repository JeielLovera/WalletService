using WalletService.Domain.Entities;
using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Business.Mapper
{
    public class CustomMapper : ICustomMapper
    {
        public Wallet ToWallet(CreateWalletDTO createWallet)
        {
            return new Wallet
            {
                InitialBalance = createWallet.Balance,
                ActualBalance = createWallet.Balance,
                UserId = createWallet.UserId,
                Title = createWallet.Title,
                Description = createWallet.Description,
                TypeWallet = createWallet.TypeWallet
            };
        }

        public WalletDTO ToWalletDTO(Wallet wallet)
        {
            return new WalletDTO
            {
                InitialBalance = wallet.InitialBalance,
                ActualBalance = wallet.ActualBalance,
                Title = wallet.Title,
                Description = wallet.Description,
                TypeWallet = wallet.TypeWallet,
                WalletId = wallet.WalletId
            };
        }

        public IEnumerable<WalletDTO> ToWalletDTO(IEnumerable<Wallet> wallets)
        {
            var walletsDTO = wallets
                .Select(x => new WalletDTO
                {
                    InitialBalance = x.InitialBalance,
                    ActualBalance = x.ActualBalance,
                    Title = x.Title,
                    Description = x.Description,
                    TypeWallet = x.TypeWallet,
                    WalletId = x.WalletId
                });

            return walletsDTO;
        }

        public WalletTransaction ToWalletTransaction(TransactionDTO transaction)
        {
            return new WalletTransaction
            {
                WalletId = transaction.WalletId!,
                Value = transaction.Value,
                Description = transaction.Description!,
            };
        }
    }
}
