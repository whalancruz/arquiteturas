using CSharp.Tools.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CSharp.Tools.Mongo.Services
{
    public class MongoService<T> : IMongoService<T> where T : MongoModel
    {
        public void Dispose() { throw new NotImplementedException(); }

    }
}