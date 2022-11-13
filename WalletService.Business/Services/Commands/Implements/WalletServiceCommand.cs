using WalletService.Business.Mapper;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Domain.Entities;
using WalletService.Domain.Models.Wallets.Requests;
using WalletService.Domain.Models.Wallets.Responses;
using WalletService.Persistence.Repositories.Interfaces;

namespace WalletService.Business.Services.Commands.Implements
{
    public class WalletServiceCommand : IWalletServiceCommand
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletLogRepository _walletLogRepository;
        private readonly ICustomMapper _mapper;

        public WalletServiceCommand(IWalletRepository walletRepository, IWalletLogRepository walletLogRepository, ICustomMapper mapper)
        {
            _walletRepository = walletRepository;
            _walletLogRepository = walletLogRepository;
            _mapper = mapper;
        }

        public async Task<WalletDTO> CreateWallet(CreateWalletDTO createWallet)
        {
            try
            {
                var wallet = _mapper.ToWallet(createWallet);
                wallet.CreatedDate = DateTime.UtcNow;
                wallet.WalletId = Guid.NewGuid().ToString();
                var walletLog = CreateFirstLog(wallet);

                await _walletRepository.CreateWallet(wallet);
                await _walletLogRepository.CreateWalletLog(walletLog);

                var walletDto = _mapper.ToWalletDTO(wallet);

                return walletDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private WalletLog CreateFirstLog(Wallet wallet)
        {
            var firstLog = new WalletLog
            {
                WalletLogId = Guid.NewGuid().ToString(),
                WalletId = wallet.WalletId,
                InitialBalance = wallet.InitialBalance,
                ActualBalance = wallet.ActualBalance,
                Datestamp = DateTime.UtcNow,
                TransactionId = null,
                TransactionValue = 0
            };

            return firstLog;
        }
    }
}
