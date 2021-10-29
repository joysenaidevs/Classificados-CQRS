using classificados.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Handlers.Contracts
{
    /// <summary>

    /// Interface generica pra qualquer tipo de objeto De QUERY

    /// T => Significa que é generico
    /// where => garante que o objeto genérico esteja herdando a interface


    /// Estou obrigando a interface manipuladora genérica ela a ter uma herança
    /// de IQuery

    /// A interface pode ser de qualquer tipo desde que herde de IQuery
    /// </summary>
    public interface IHandlerQuery<T> where T : IQuery
    {
        // espero que venha um resultado do IQueryResult
        IQueryResult Handler(T query);

    }
}
