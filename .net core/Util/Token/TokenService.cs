
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entitys;
using Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace Util.JWT
{
    public class TokenService : ITokenServices
    {

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarTokenAcesso(UsersEntity usuario)
        {
            var SecretKey = _configuration["ChaveJwt:SecretKey"];

            if (string.IsNullOrEmpty(usuario.Email)) throw new Exception("ChaveJwt: Email não configurada no arquivo de configuração.");
            if (string.IsNullOrEmpty(usuario.Nome)) throw new Exception("ChaveJwt: Nome não configurada no arquivo de configuração.");
            if (string.IsNullOrEmpty(SecretKey)) throw new Exception("ChaveJwt: Chave não configurada no arquivo de configuração.");

            // Criar claims (pode ser customizado de acordo com suas necessidades)
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, usuario.Nome),
               new Claim(ClaimTypes.Name, usuario.Nome),
               new Claim(ClaimTypes.Email, usuario.Email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            // Gerar a chave secreta a partir da configuração
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            // Configurar a assinatura do token JWT
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Criar o token JWT
            var token = new JwtSecurityToken(
                issuer: _configuration["ChaveJwt:Issuer"],
                audience: _configuration["ChaveJwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["ChaveJwt:ExpirationHours"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var key = _configuration["ChaveJwt:SecretKey"];

            if (string.IsNullOrEmpty(key)) throw new Exception("ChaveJwt:SecretKey não configurada no arquivo de configuração.");
            if (string.IsNullOrEmpty(token)) throw new Exception("ChaveJwt:Token não configurada no arquivo de configuração.");

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = _configuration["ChaveJwt:Issuer"],
                ValidAudience = _configuration["ChaveJwt:Audience"],
                IssuerSigningKey = securityKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                // Valida o token e obtém o ClaimsPrincipal associado a ele
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenValidationException ex)
            {
                // Captura a exceção de validação do token e fornece uma mensagem de erro mais detalhada
                throw new Exception("ChaveJwt: Falha na validação do token. Detalhes do erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Captura outras exceções e fornece uma mensagem de erro genérica
                throw new Exception("ChaveJwt: Aconteceu algo inesperado. Detalhes do erro: " + ex.Message);
            }

        }
    }

}