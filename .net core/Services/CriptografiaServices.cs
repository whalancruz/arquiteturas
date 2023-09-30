using Interfaces.Services;
using BCrypt;
using System;
using System.Security.Cryptography;

public class CriptografiaServices : ICriptografiaServices
{

    // Método para criar o hash da senha
    public string CriarHashSenha(string senha)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(); // Gerar salt usando a biblioteca BCrypt
        return BCrypt.Net.BCrypt.HashPassword(senha, salt);
    }

    // Método para verificar a senha
    public bool VerificarSenha(string senhaDigitada, string hashSenha)
    {
        return BCrypt.Net.BCrypt.Verify(senhaDigitada, hashSenha);
    }

}