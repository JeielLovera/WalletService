using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Models.Wallets.Requests
{
    public class CreateWalletDTO
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeWallet { get; set; }
    }
}
