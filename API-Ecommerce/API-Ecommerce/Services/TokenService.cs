using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_Ecommerce.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            // Claims - informacoes do usuário que quero guardar
            // Definição das informações (claims) que serão armazenadas no token
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email)
        };

            // Criação da chave secreta utilizada para assinar o token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-mega-ultra-segura-senai"));


        }
    }
