using classificados.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Handlers.Contracts
{
    /// <summary>
   
    /// Interface generica pra qualquer tipo de objeto De comando
    
    /// T => Significa que é generico
    /// where => garante que o objeto genérico esteja herdando a interface
    

    /// Estou obrigando a interface manipuladora genérica ela a ter uma herança
    /// de ICommand
   
    /// A interface pode ser de qualquer tipo desde que herde de ICommand
    /// </summary>
    public interface IHandlerCommand<T> where T : ICommand
    {
        // espero que venha um resultado do ICommandResult
        ICommandResult Handler(T command);

    }
}
