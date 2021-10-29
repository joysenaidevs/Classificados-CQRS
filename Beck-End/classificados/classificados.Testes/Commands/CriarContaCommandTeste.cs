using classificados.Dominio.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace classificados.Testes.Commands
{
    public class CriarContaCommandTeste
    {
        [Fact]
        public void DeveRetornarBomSeDadosForemValidos()
        {
            // instancia indo para o método vazio
            var command = new CriarContaCommand();
            command.Nome = "Joyce";
            command.Email = "adm@email.com";
            command.Senha = "123456789";
            command.TipoUsuario = Comum.EnTipoUsuario.Adimin;

            // para que eu consiga fazer a verificacao
            command.Validar();



            Assert.True(command.IsValid, "Os dados foram preenchidos corretamente!");

           
        }

    }
}
