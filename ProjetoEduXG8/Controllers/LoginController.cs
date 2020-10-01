using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoEduXAPI.Utils;
using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;

namespace ProjetoEduXG8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        EduXContext _context = new EduXContext();

        private IConfiguration _configuracao;

        public LoginController(IConfiguration config)
        {
            _configuracao = config;
        }

        private Usuario AuthenticateUser(Usuario login)
        {
            login.Senha = Crypto.Criptografar(login.Senha, login.Email.Substring(0, 4));

            return _context.Usuarios.Include(a => a.IdAcessoNavigation).FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        }

        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracao["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, userInfo.IdAcessoNavigation.Permissao)
        };


            var token = new JwtSecurityToken
                (
                    _configuracao["Jwt:Issuer"],
                    _configuracao["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usuario login)
        {

            IActionResult responta = Unauthorized();

            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                responta = Ok(new { token = tokenString });
            }

            return responta;
        }
    }
}