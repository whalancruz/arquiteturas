using CSharp.Tools.Migrations;
using CSharp.Tools.Ninject;
using CSharp.Tools.Routers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CSharp
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(new Routers());

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            InitNinject(config);

            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<CSharp.Tools.Migrations.MyDbContext, CSharp.Migrations.Configuration>());
        }

        public static void InitNinject(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(LoadNinjectModules());
            config.DependencyResolver = new NinjectDependecy(kernel);
        }

        public static IEnumerable<Assembly> LoadNinjectModules() { return AppDomain.CurrentDomain.GetAssemblies(); }
    }
}
