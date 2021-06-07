using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Tools.Mongo.Models
{
    public interface IMongoModel
    {
        ObjectId _Id { get; set; }

        string Id { get; set; }

        string __v { get; set; }
    }
}