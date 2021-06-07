using CSharp.Tools.Mongo.Models;
using CSharp.Tools.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CSharp.Tools.Mongo.Controllers
{
    public class MongoController<T> : ApiController where T : class, IMongoModel
    {
        public IMongoService<T> _service;

        public MongoController(IMongoService<T> service) { _service = service; }

        //[HttpGet]
        //[Route("teste")]
        //public async Task<IHttpActionResult> Teste()
        //{
        //    return Ok();
        //}
    }
}