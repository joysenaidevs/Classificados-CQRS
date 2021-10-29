using classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace classificados.Testes.Entidades
{
    /// <summary>
    /// classe de teste para Entidade Produto
    /// </summary>
    public class ProdutoTeste
    {
        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeProdutoEValido()
        {
            Produto produto = new Produto(
              "Smat Tv",
              "Esta Televisão tem 150polegadas e um controle",
              "smarttv.png",
                8000,
              Comum.Enum.EnStatusProduto.Ativo
           );

            //         metodo usado para verificar que condições devem ser encontradas durante o processo
            //         de testes
            Assert.True(produto.IsValid, "Produto valido");
        }

        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeProdutoForInvalidoSemDescricao()
        {
            Produto produto = new Produto(
               
              "Smat Tv",
              "",
              "smarttv.png",
                8000,
              Comum.Enum.EnStatusProduto.Ativo
           );

            Assert.True(!produto.IsValid, "Produto Invalido sem Descrição");
        }

        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeProdutoNaoTiverImagem()
        {
            Produto produto = new Produto(
             "Smat Tv",
              "Esta Televisão tem 150polegadas e um controle",
              "",
                8000,
              Comum.Enum.EnStatusProduto.Inativo
           );

            Assert.True(!produto.IsValid, "Impossivel cadastrar, Produto Inativo!");

        }
    }


}

