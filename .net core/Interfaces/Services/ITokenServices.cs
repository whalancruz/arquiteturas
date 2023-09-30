using System.Security.Claims;
using Entitys;
using Interfaces.Generic;

namespace Interfaces.Services
{
    public interface ITokenServices
    {
        string GerarTokenAcesso(UsersEntity usuario);
        ClaimsPrincipal ValidateToken(string token);
    }
}