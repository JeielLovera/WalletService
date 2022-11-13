using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Models.Transactions.Requests
{
    public class TransactionDTO
    {
        public string? WalletId { get; set; }
        public decimal Value { get; set; }
        public string? Description { get; set; }
    }
}
