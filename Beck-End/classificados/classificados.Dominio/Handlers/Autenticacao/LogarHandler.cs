using classificados.Comum.Commands;
using classificados.Comum.Handlers.Contracts;
using classificados.Comum.Utils;
using classificados.Dominio.Commands.Usuario;
using classificados.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Handlers.Autenticacao
{
    public class LogarHandler : Notifiable<Notification>, IHandlerCommand<EfetuarLoginCommand>
    {// injeção de dependencia
        private IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            // injetando dependencia na criação da classe
            _usuarioRepositorio = usuarioRepositorio;
        }


        public ICommandResult Handler(EfetuarLoginCommand command)
        {
            //         --------validar nosso comando---------
            command.Validar();

            // se não for valido
            if (!command.IsValid)
            {
                //vou retornar :
                return new GenericCommandResult
                (
                    false,
                    "Informe corretamente os dados do usuario",
                    command.Notifications

                );
            }

            //buscar usuario por email
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            //usuario existe?
            if (usuario == null)
                return new GenericCommandResult(false, "Usuario inexistente", null);

            // validar hashes
            //verificar se nao deu match, caso contrario se for falso, retorna Senha invalida 
            if (!Senha.ValidarHashes(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Dados invalidos!", null); 


            return new GenericCommandResult(true, "Logado com Sucesso!", usuario);
        }
    }
}
