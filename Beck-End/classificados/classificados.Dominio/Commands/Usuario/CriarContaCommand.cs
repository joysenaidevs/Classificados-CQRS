﻿using classificados.Comum;
using classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Commands
{
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        //metodo construtor vazio para poder atribuir os dados do objeto
        public CriarContaCommand()
        {

        }


        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio!")
                   .IsEmail(Email, "Email", "O formato do email está incorreto!")
                   .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos  8 caracteres")
           );
        }
    }
}
