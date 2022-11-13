using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.Entities;

namespace WalletService.Domain.Models.Wallets.Responses
{
    public class WalletDTO
    {
        public string WalletId { get; set; }
        public decimal ActualBalance { get; set; }
        public decimal InitialBalance { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeWallet { get; set; }
    }
}
