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
    public class ObterDadosCommand : Notifiable<Notification>, ICommand
    {
        // metodo construtor vazio para poder atribuir os dados do objeto
        public ObterDadosCommand()
        {

        }

        public ObterDadosCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Guid IdUsuario { get; set; }


        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                    .IsNotNull(IdUsuario, "IdUsuario", "o Id do Usuario não pode ser null!")

            );
                   
        }
    }
}
