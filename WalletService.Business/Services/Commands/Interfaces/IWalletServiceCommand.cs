using WalletService.Domain.Models.Wallets.Requests;
using WalletService.Domain.Models.Wallets.Responses;

namespace WalletService.Business.Services.Commands.Interfaces
{
    public interface IWalletServiceCommand
    {
        Task<WalletDTO> CreateWallet(CreateWalletDTO createWallet);
    }
}
