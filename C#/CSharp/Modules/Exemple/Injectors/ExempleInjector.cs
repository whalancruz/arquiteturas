using CSharp.Modules.Exemple.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Modules.Exemple.Injectors
{
    public class ExempleInjector : NinjectModule
    {
        public override void Load()
        {
            Bind<IExempleService>().To<ExempleService>();
        }
    }
}