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
    class AlterarSenhaCommand : Notifiable<Notification>, ICommand
    {
  //    metodo construtor vazio para poder atribuir os dados do objeto
        public AlterarSenhaCommand()
        {

        }

        public AlterarSenhaCommand(string senha)
        {
            Senha = senha;
        }

        public string Senha { get; set; }

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos  8 caracteres")
           );
        }
    }
}
