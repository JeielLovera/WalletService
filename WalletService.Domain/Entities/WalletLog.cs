using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Entities
{
    public class WalletLog
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string WalletLogId { get; set; }
        public string WalletId { get; set; }
        public string? TransactionId { get; set; }
        public decimal ActualBalance { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime Datestamp { get; set; }
    }
}
