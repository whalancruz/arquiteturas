
using Entitys;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using uteis;

namespace Controllers
{
    public class UsersController : GenericController<IUsersServices, UsersEntity>
    {

        IUsersServices _usersServices;

        public UsersController(IKernel kernel) : base(kernel.Get<IUsersServices>())
        {
            _usersServices = kernel.Get<IUsersServices>();
        }
    }
}