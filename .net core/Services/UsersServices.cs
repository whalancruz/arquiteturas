using Entitys;
using Interfaces.Services;
using Ninject;
using Util.Generic;

namespace Services
{
    public class UsersServices : GenericServices<UsersEntity>, IUsersServices
    {

        public IConfiguration _configuration { get; }
        public ICriptografiaServices _criptografiaServices { get; }

        public UsersServices(DbContexto dbContexto, IConfiguration configuration, IKernel kernel) : base(dbContexto)
        {
            _configuration = configuration;
            _criptografiaServices = kernel.Get<ICriptografiaServices>();
        }

        public override UsersEntity onPrevInsert(UsersEntity usuario)
        {
            if (string.IsNullOrEmpty(usuario.Password)) throw new Exception("Error: Senha informada e null");

            var usuarioInsert = this.DbQueryable().FirstOrDefault(x => x.Nome == usuario.Nome && x.Email == usuario.Email);

            if (usuarioInsert != null) throw new Exception("Usuario ja existe não é possivel adicionar.");

            usuario.Password = _criptografiaServices.CriarHashSenha(usuario.Password);

            return usuario;
        }

    }
}