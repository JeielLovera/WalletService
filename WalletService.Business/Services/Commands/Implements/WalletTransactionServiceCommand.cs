using WalletService.Business.Mapper;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Domain.Entities;
using WalletService.Domain.Models.Transactions.Requests;
using WalletService.Domain.Models.Wallets.Responses;
using WalletService.Persistence.Repositories.Interfaces;

namespace WalletService.Business.Services.Commands.Implements
{
    public class WalletTransactionServiceCommand : IWalletTransactionServiceCommand
    {
        private readonly IWalletTransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletLogRepository _logRepository;
        private readonly ICustomMapper _mapper;

        public WalletTransactionServiceCommand(
            IWalletTransactionRepository transactionRepository,
            IWalletRepository walletRepository,
            IWalletLogRepository logRepository,
            ICustomMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<WalletDTO?> ExcuteTransaction(TransactionDTO transaction)
        {
            try
            {
                if (transaction.WalletId == null || transaction.Value == 0) return null;

                var wallet = await _walletRepository.FindWalletByWalletId(transaction.WalletId);

                if (wallet == null) return null;

                var dateStamp = DateTime.UtcNow;

                wallet.ActualBalance = wallet.ActualBalance + transaction.Value;

                var newTransaction = _mapper.ToWalletTransaction(transaction);
                newTransaction.WalletTransactionId = Guid.NewGuid().ToString();
                newTransaction.Datestamp = dateStamp;

                await _transactionRepository.CreateWalletTransaction(newTransaction);
                await _walletRepository.UpdateWallet(wallet);

                var newWalletLog = new WalletLog
                {
                    WalletLogId = Guid.NewGuid().ToString(),
                    WalletId = wallet.WalletId,
                    InitialBalance = wallet.InitialBalance,
                    ActualBalance = wallet.ActualBalance,
                    TransactionId = newTransaction.WalletTransactionId,
                    TransactionValue = newTransaction.Value,
                    Datestamp = dateStamp
                };

                await _logRepository.CreateWalletLog(newWalletLog);

                var walletDTO = _mapper.ToWalletDTO(wallet);

                return walletDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

    }
}
