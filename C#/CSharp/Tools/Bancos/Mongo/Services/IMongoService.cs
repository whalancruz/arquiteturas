using CSharp.Tools.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Tools.Mongo.Services
{
    public interface IMongoService<T> : IDisposable where T : IMongoModel
    {


    }
}