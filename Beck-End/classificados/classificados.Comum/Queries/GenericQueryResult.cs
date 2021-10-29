using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Queries
{
    /// <summary>
    /// Classe genérica das queries
    /// </summary>
    public class GenericQueryResult : IQueryResult
    {

        public GenericQueryResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public Object Data { get; private set; }

    }

}
