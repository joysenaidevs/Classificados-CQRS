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
    public class ExcluirProdutoHandle : Notifiable<Notification>, IHandlerCommand<ExcluirProdutoCommand>
    {
        // injeção de dependencia
        private IProdutoRepositorio _produtoRepositorio;

        public ExcluirProdutoHandle(IProdutoRepositorio produtoRepositorio)
        {
            // injetando dependencia na criação da classe
            _produtoRepositorio = produtoRepositorio;
        }
        public ICommandResult Handler(ExcluirProdutoCommand command)
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
                    "Esse produto não foi excluido",
                    command.Notifications

                );
            }

           
            ExcluirProdutoCommand idProduto = new ExcluirProdutoCommand (command.IdProduto, command.Status);
            if (!idProduto.IsValid)
                return new GenericCommandResult(false, "Dados Invalidos do produto!", idProduto.Notifications);


            //Excluir Pacote no banco
            _produtoRepositorio.Deletar(idProduto.IdProduto);


            //retornar sucesso
            return new GenericCommandResult(true, "Produto Excluido!", IsValid);

        }
    }
}
