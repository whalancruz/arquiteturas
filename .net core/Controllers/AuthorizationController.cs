using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Ninject;

namespace Controllers
{

    [Route("api/v1/[controller]")]
    public class AuthorizationController : ControllerBase
    {

        private readonly IAuthorizationServices _authorization;

        public AuthorizationController(IKernel kernel)
        {
            _authorization = kernel.Get<IAuthorizationServices>();
        }

        [HttpPost]
        public ActionResult Login([FromBody] AuthorizationModel param)
        {
            var response = _authorization.Authorization(param);

            return Ok(new { Token = "Bearer " + response });
        }
    }
}