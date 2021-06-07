using CSharp.Modules.Exemple.Models;
using CSharp.Modules.Exemple.Services;
using CSharp.Tools.Bancos.Sql.Controllers;
using CSharp.Tools.Mongo.Controllers;
using CSharp.Tools.Navigated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CSharp.Modules.Exemple.Controllers
{
    [Navigated("exemple")]
    public class ExempleController : SqlController<ExempleModel>
    {
        public IExempleService _service;

        public ExempleController(IExempleService service): base(service) { _service = service;  }

        [HttpGet]
        [Route("teste")]
        public async Task<IHttpActionResult> Teste()
        {
            await _service.HellowWord();

            return Ok(true);
        }

    }
}