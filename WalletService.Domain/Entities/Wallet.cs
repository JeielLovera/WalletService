using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Entities
{
    public class Wallet
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string UserId { get; set; }
        public string WalletId { get; set; }
        public decimal ActualBalance { get; set; }
        public decimal InitialBalance { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeWallet { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
