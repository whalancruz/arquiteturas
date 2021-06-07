using CSharp.Tools.Bancos.Sql.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Tools.Bancos.Sql.Injectors
{
    public class SqlInjector : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ISqlService<>)).To(typeof(SqlService<>));
        }
    }
}