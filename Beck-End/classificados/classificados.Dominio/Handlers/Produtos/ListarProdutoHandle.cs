using classificados.Comum.Handlers.Contracts;
using classificados.Comum.Queries;
using classificados.Dominio.Queries.Produto;
using classificados.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static classificados.Dominio.Queries.Produto.ListarProdutoAtivoQuery;

namespace classificados.Dominio.Handlers.Produtos
{
    /// <summary>
    /// manipulação de query e command
    /// </summary>
    public class ListarProdutoHandle : IHandlerQuery<ListarProdutoAtivoQuery>
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        //metdo construtor
        public ListarProdutoHandle(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }


        public IQueryResult Handler(ListarProdutoAtivoQuery query)
        {
            // listamos todos os produtos 
            var produtos = _produtoRepositorio.Listar(query.Ativo);

                //tratar ( limpamos as informações necessarias )
                // limpamos as informações desnecessarias
                var retornoProdutos = produtos.Select(
                    x =>
                    {
                        return new ListarProdutoResult()
                        {
                            Id = x.Id,
                            Nome = x.Nome,
                            Imagem = x.Imagem,
                            Descricao = x.Descricao,
                            Date = x.Date,
                       
                        };
                    }
                );

            return new GenericQueryResult(true, "Estes são os produtos ativos existentes!", retornoProdutos);

        }
    }
}
