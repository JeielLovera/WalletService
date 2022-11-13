using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Business.Mapper;
using WalletService.Business.Services.Querys.Interfaces;
using WalletService.Domain.Models.Wallets.Responses;
using WalletService.Persistence.Repositories.Interfaces;

namespace WalletService.Business.Services.Querys.Implements
{
    public class WalletServiceQuery : IWalletServiceQuery
    {
        private readonly IWalletRepository _repository;
        private readonly ICustomMapper _mapper;

        public WalletServiceQuery(IWalletRepository repository, ICustomMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<WalletDTO>> GetWalletsByUserId(string userId)
        {
            try
            {
                var wallets = await _repository.GetWalletsByUserId(userId);
                var walletDTOs = _mapper.ToWalletDTO(wallets);
                return walletDTOs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
