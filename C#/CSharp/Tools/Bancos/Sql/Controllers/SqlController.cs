using CSharp.Tools.Bancos.Sql.Models;
using CSharp.Tools.Bancos.Sql.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CSharp.Tools.Bancos.Sql.Controllers
{
    public class SqlController<T> : ApiController where T : class, ISqlModel
    {
        public ISqlService<T> _service;

        public SqlController(ISqlService<T> service) { _service = service; }

        //[HttpPost]
        //[Route("create")]
        //public async Task<IHttpActionResult> Create([FromBody] T obj)
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("update")]
        //public async Task<IHttpActionResult> Update([FromBody] T obj)
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("delete/{id}")]
        //public async Task<IHttpActionResult> Delete([FromUri] string id)
        //{
        //    return Ok(true);
        //}

    }
}