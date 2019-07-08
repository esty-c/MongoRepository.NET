using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository.Infrastructure.Model;

namespace MongoRepository.Models
{
    public class User : IEntity
    {
        [BsonId]
        public ObjectId ID { get; set; }

        public String Name { get; set; }
        public String Address { get; set; }
    }
}