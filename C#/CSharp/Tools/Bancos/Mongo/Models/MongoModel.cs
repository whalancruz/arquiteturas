using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Tools.Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class MongoModel : IMongoModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [BsonId]
        public ObjectId _Id { get; set; }

        public string Id { get; set; }

        [JsonIgnore]
        public string __v { get; set; }

    }
}