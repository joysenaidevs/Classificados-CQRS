using classificados.Comum.Handlers.Contracts;
using classificados.Comum.Queries;
using classificados.Dominio.Entidades;
using classificados.Dominio.Queries.Produto;
using classificados.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static classificados.Dominio.Queries.Produto.ListarMeusProdutosQuery;

namespace classificados.Dominio.Handlers.Produtos
{
    public class ListarMeusProdutosHandle : IHandlerQuery<ListarMeusProdutosQuery>
    {

        private readonly IProdutoRepositorio _produtoRepositorio;

        //metdo construtor
        public ListarMeusProdutosHandle(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IQueryResult Handler(ListarMeusProdutosQuery query)
        {
            // listamos todos os produtos 
            List<Produto> produtos = _produtoRepositorio.ListarMinhas(query.idUsuario);
         
            return new GenericQueryResult(true, "Estes são os seus produtos!", produtos);
        }
    }
}
