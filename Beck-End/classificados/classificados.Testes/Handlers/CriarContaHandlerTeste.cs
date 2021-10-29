using classificados.Comum.Commands;
using classificados.Dominio.Commands;
using classificados.Dominio.Handlers;
using classificados.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace classificados.Testes.Handlers
{
    public class CriarContaHandlerTeste
    {
        [Fact]
        public void DeveRetornarCasoDadosHandleSejamValidos()
        {
            //criar um comando 
            var command = new CriarContaCommand();
            command.Email = "adm@email.com";
            command.Nome = "Joyce";
            command.Senha = "12345678910";
            command.TipoUsuario = Comum.EnTipoUsuario.Adimin;

            // criar manipulador
            var handle = new CriarContaHandler(new FakeUsuarioRepositorio());

            // Pegar resultados
            var resultado = (GenericCommandResult)handle.Handler(command);

            // validar a condicao
            Assert.True(resultado.Sucesso, "usuario válido");
        }
    }
}
