﻿using System.Security.Claims;

namespace API_Ecommerce.Services
{
    public class TokenServiceBase
    {
        public string GenerateToken(string email)
        {
            // Claims - informacoes do usuário que quero guardar
            // Definição das informações (claims) que serão armazenadas no token
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email)
        };



        }
    }
}