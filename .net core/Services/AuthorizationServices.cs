using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Services;
using Models;
using Ninject;

namespace Services
{
    public class AuthorizationServices : IAuthorizationServices
    {
        public IUsersServices _usersServices;
        public ICriptografiaServices _criptografiaServices { get; }
        public ITokenServices _tokenService;
        public AuthorizationServices(IUsersServices usersServices, IKernel kernel)
        {
            _usersServices = usersServices;
            _criptografiaServices = kernel.Get<ICriptografiaServices>();
            _tokenService = kernel.Get<ITokenServices>();
        }

        public string Authorization(AuthorizationModel parametros)
        {
            if (string.IsNullOrEmpty(parametros.Password)) throw new Exception("Error: Senha informada e null");

            var usuarioInsert = this._usersServices.DbQueryable().FirstOrDefault(x => x.Email == parametros.Email);
            if (usuarioInsert == null) throw new Exception("Aconteceu algo inesperado.");

            var hash = _criptografiaServices.VerificarSenha(parametros.Password, usuarioInsert.Password);
            if (!hash) throw new Exception("Aconteceu algo inesperado.");

            return _tokenService.GerarTokenAcesso(usuarioInsert);
        }

    }
}