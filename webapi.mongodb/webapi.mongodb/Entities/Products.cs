using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.mongodb.Entities
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Client> Clients { get; set; }

        [BsonElement("Direction")]
        public Direction DirectionClient { get; set; }

    }
}
