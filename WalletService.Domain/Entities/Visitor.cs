using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.Entities
{
    public class Visitor
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
