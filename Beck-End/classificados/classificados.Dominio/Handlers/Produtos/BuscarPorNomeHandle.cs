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

namespace classificados.Dominio.Handlers.Produtos
{
    public class BuscarPorNomeHandle : IHandlerQuery<BuscarPorNomeQuery>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        //metdo construtor
        public BuscarPorNomeHandle(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IQueryResult Handler(BuscarPorNomeQuery query)
        {
            // Buscamos o nome do produto
            var produtos = _produtoRepositorio.BuscarPorNome(query.Nome);



            return new GenericQueryResult(true, "Estes são os produtos existentes!", produtos);

        }
    }
}
