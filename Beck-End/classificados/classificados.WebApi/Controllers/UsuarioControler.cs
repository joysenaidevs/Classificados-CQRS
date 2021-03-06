using classificados.Comum.Commands;
using classificados.Dominio;
using classificados.Dominio.Commands;
using classificados.Dominio.Commands.Usuario;
using classificados.Dominio.Handlers;
using classificados.Dominio.Handlers.Autenticacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace classificados.WebApi.Controllers
{
    // Entrada da API => rota da api/ rota v1 / na conta de usuario account
    [Route("v1/account")]

    // controlador de api de usuario
    [ApiController]
    public class UsuarioControler : ControllerBase
    {
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult Signup(CriarContaCommand command, [FromServices] CriarContaHandler handler )
        {
            // transformando o retorno do handle em genericCommand
            return (GenericCommandResult)handler.Handler(command);
        }

        // rota da api
        [Route("signin")]
        [HttpPost]
        // criar método logar
        public GenericCommandResult SignIn(EfetuarLoginCommand command, [FromServices] LogarHandler handle)
        {
            var resultado = (GenericCommandResult)handle.Handler(command);

            // verificamos se o resultado deu sucesso para gerar token
            if (resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);

                // com o token gerado retorna:
                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { Token = token });

            }

            // caso não passe pelo token
            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }



        // Criamos nosso método que vai gerar nosso Token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaClassificadosSenai132"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
            new Claim("role", userInfo.TipoUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "classificados",
                    "classificados",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
