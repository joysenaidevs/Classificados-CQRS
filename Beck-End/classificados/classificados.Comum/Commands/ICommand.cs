using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Commands
{
    /// <summary>
    /// Interface fundamental para validar informações
    /// </summary>
    public interface ICommand
    {
        void Validar()
        {
                    // sem validações                            
        }
    }
}
