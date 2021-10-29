using classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Commands.Usuario
{
    public class ListarCommand : Notifiable<Notification>, ICommand
    {
        public ListarCommand(string nome)
        {
            Nome = nome;    
        
        }

        public string Nome { get; set; }
      

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsEmail(Nome, "Nome", "Este usuario não existe!")
                   
           );
        }
    }
}
