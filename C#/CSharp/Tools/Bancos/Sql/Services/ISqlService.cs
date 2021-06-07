using CSharp.Tools.Bancos.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CSharp.Tools.Bancos.Sql.Services
{
    public interface ISqlService<T> : IDisposable where T : ISqlModel
    {

        Task HellowWord(); 

    }
}