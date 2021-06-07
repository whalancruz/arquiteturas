using CSharp.Modules.Exemple.Models;
using CSharp.Tools.Bancos.Sql.Services;
using CSharp.Tools.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CSharp.Modules.Exemple.Services
{
    public interface IExempleService : ISqlService<ExempleModel>
    {
        Task HellowWord(); 

    }
}