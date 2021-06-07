using CSharp.Modules.Exemple.Models;
using CSharp.Tools.Bancos.Sql.Services;
using CSharp.Tools.Migrations;
using CSharp.Tools.Mongo.Services;
using CSharp.Tools.Ninject;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CSharp.Modules.Exemple.Services
{
    public class ExempleService : SqlService<ExempleModel>, IExempleService
    {
        public Task HellowWord()
        {
            using (var intercontexto = Factory.InstanceOf<MyDbContext>())
            {


                throw new NotImplementedException();
            }
        }
    }
}