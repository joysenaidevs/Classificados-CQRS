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
    public class AlterarProdutoHandle : Notifiable<Notification>, IHandlerCommand<AlterarProdutoCommand>
    {
        // injeção de dependencia
        private IProdutoRepositorio _produtoRepositorio;

        public AlterarProdutoHandle(IProdutoRepositorio produtoRepositorio)
        {
            // injetando dependencia na criação da classe
            _produtoRepositorio = produtoRepositorio;
        }


        public ICommandResult Handler(AlterarProdutoCommand command)
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
                    "Altere corretamente os dados do produto",
                    command.Notifications

                );
            }

            //       --------- Busca o produto através do seu ID --------
            var produtoNaoExiste = _produtoRepositorio.BuscarPorId(command.Id);
            // se produto ja existe
            if (produtoNaoExiste != null)
                return new GenericCommandResult(true, "Produto ja existente!", "Cadastre outro Produto");

            //SE ELE NAO EXISTIR = Criar uma instacia de Produto
            Produto produto = new Produto(command.Nome, command.Descricao, command.Imagem,command.Preco,command.Status);
            if (!produto.IsValid)
                return new GenericCommandResult(false, "Dados Invalidos do produto!", produto.Notifications);
            //Alterar Produto no banco
            _produtoRepositorio.Alterar(produto);

            //retornar sucesso
            return new GenericCommandResult(true, "Produto Alterado!", produto);

        }
    }
}
