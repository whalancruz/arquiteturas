using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CSharp.Modules.Exemple.Models;

namespace CSharp.Tools.Migrations
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("arquitetura")
        {
            Database.SetInitializer<MyDbContext>(new MigrateDatabaseToLatestVersion<MyDbContext, CSharp.Migrations.Configuration>());
        }

        public virtual DbSet<ExempleModel> ExempleModel { get; set; }
    }
}