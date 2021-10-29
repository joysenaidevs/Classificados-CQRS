
using classificados.Dominio.Commands.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace classificados.Testes.Commands
{
    /// <summary>
    /// Teste para cadastrar produto
    /// </summary>
    public class CadastrarProdutoCommandTeste
    {
        [Fact]
        public void DeveRetornarBomSeDadosForemValidos()
        {
            // instancia indo para o método vazio
            var command = new CadastrarProdutoCommand();
            command.Nome = "Iphone 7 plus";
            command.Descricao = "Smarthphone avançado";
            command.Preco = 8000;
            command.Imagem = "iphone.png";
            command.Status = Comum.Enum.EnStatusProduto.Ativo;

            // para que eu consiga fazer a verificacao
            command.Validar();



            Assert.True(command.IsValid, "Os dados foram preenchidos corretamente!");


        }
    }
}
