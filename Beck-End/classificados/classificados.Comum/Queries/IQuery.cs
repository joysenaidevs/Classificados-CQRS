using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Queries
{
    /// <summary>
    /// Interface responsavel pelas queries
    /// </summary>
    public interface IQuery
    {
        // objeto de validação
        void Validar();
    }
}
