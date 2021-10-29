using classificados.Comum.Commands;
using classificados.Comum.Handlers.Contracts;
using classificados.Dominio.Commands.Produto;
using classificados.Dominio.Entidades;
using classificados.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Handlers.Produtos
{
    public class CadastrarProdutoHandle : Notifiable<Notification>, IHandlerCommand<CadastrarProdutoCommand>
    {
        // ---------------------------- Injeção de dependencia -----------------------------
        private readonly IProdutoRepositorio _produtoRepositorio;



        // vamos obrigar que IProdutoRepositorio e produtoRepositorio seja instanciada na classe
        // injecao de dependencia : cadastrarProduto Handle depende de uma repositorio que vai gerar uma classe
        public CadastrarProdutoHandle(IProdutoRepositorio produtoRepositorio)
        {
            // injetando dependencia na criação da classe
            _produtoRepositorio = produtoRepositorio;
        }

        public ICommandResult Handler(CadastrarProdutoCommand command)
        {
            //         --------validar nosso comando---------
            command.Validar();

            // se não for valido
            if (!command.IsValid)
            {
                //vou retornar :
                return new GenericCommandResult
                (
                    false,
                    "Informe corretamente os dados do produto",
                    command.Notifications

                );
            }


            //       --------- verificar se o produto existe  com o mesmo nome --------
            var produtoExiste = _produtoRepositorio.BuscarPorNome(command.Nome);
            // se produto ja existe
            if (produtoExiste != null)
                return new GenericCommandResult(false, "Produto ja existente!", "Cadastre outro Produto");

            // SE ELE NAO EXISTIR = Criar uma instacia de pacote
            Produto produto = new Produto(command.Nome,command.Descricao, command.Imagem, command.Preco,command.Status);
            if (!produto.IsValid)
                return new GenericCommandResult(false, "Dados Invalidos do produto!", produto.Notifications);

            //Adicionar Pacote no banco
            _produtoRepositorio.Cadastrar(produto);

            //retornar sucesso
            return new GenericCommandResult(true, "Produto cadastrado!", produto);
        }
    }
}
