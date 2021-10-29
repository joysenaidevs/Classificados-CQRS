using classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Commands.Autenticacao
{
    public class RecuperarSenhaCommand : Notifiable<Notification>, ICommand
    {
        // metodo construtor vazio para poder atribuir os dados do objeto
        public RecuperarSenhaCommand()
        {

        }
        public RecuperarSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsEmail(Email, "Email", "Informe seu e-mail para recuperar senha!")
                  
           );
        }
    }
}
