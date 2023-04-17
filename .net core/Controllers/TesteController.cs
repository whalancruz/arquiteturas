using Entitys;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using uteis;

namespace Controllers
{
    public class TesteController : GenericController<ITesteServices, TesteEntity>
    {

        private readonly ITesteServices _testeServices;

        public TesteController(IKernel kernel) : base(kernel.Get<ITesteServices>())
        {
            _testeServices = kernel.Get<ITesteServices>();
        }

    }
}