using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Entities
{
    public class WalletTransaction
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string WalletTransactionId { get; set; }
        public string WalletId { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime Datestamp { get; set; }

    }
}
