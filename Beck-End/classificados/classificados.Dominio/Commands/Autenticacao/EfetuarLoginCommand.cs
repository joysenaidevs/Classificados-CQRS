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
    public class EfetuarLoginCommand : Notifiable<Notification>, ICommand
    {
        //metodo construtor vazio para poder atribuir os dados do objeto
        public EfetuarLoginCommand()
        {

        }

        public EfetuarLoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsEmail(Email, "Email", "O formato do email está incorreto!")
                   .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos  8 caracteres")
           );
        }
    }
}
