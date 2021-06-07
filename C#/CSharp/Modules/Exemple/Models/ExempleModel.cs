using CSharp.Tools.Bancos.Sql.Models;
using CSharp.Tools.Mongo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSharp.Modules.Exemple.Models
{

    [Table("cliente")]
    public class ExempleModel : SqlModel
    {
        public string nome { get; set; }

        public int numero { get; set; }
    }
}