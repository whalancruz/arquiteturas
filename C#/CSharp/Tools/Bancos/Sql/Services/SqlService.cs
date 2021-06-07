using CSharp.Tools.Bancos.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using CSharp.Tools.Ninject;
using CSharp.Tools.Migrations;

namespace CSharp.Tools.Bancos.Sql.Services
{
    public class SqlService<T> : ISqlService<T> where T : SqlModel
    {
        public void Dispose() { throw new NotImplementedException(); }

        public SqlService() { this.InitConnection(); }

        private void InitConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString);


        }

        public virtual async Task HellowWord()
        {
            using (var intercontexto = Factory.InstanceOf<MyDbContext>())
            {

                var teste = intercontexto.ExempleModel.AsQueryable();


                throw new NotImplementedException();
            }
        }
    }
}