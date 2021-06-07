using CSharp.Tools.Mongo.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Tools.Mongo.Injectors
{
    public class MongoInjector : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IMongoService<>)).To(typeof(MongoService<>));
        }
    }
}