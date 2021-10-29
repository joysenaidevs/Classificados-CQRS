using classificados.Comum.Commands;
using classificados.Comum.Handlers.Contracts;
using classificados.Comum.Utils;
using classificados.Dominio.Commands;
using classificados.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Handlers
{
    public class CriarContaHandler : Notifiable<Notification>, IHandlerCommand<CriarContaCommand>
    {
        // injeção de dependencia
        private IUsuarioRepositorio _usuarioRepositorio;

        public CriarContaHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            // injetando dependencia na criação da classe
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(CriarContaCommand command)
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


            //       --------- verificar se o email existe --------
            var UsuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
                            // se email ja existe
            if (UsuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado!", "Informe outro email");


            //          --------criptografar minha senha-------
           
            command.Senha = Senha.Criptografar(command.Senha);


            //  -------salvar no Banco => repositorio.Adicionar(usuario);-------
            Usuario u1 = new Usuario
               (
                   command.Nome,
                   command.Email,
                   command.Senha,
                   command.TipoUsuario

               );
            //se ele nao for valido, retorna um erro
            if (!u1.IsValid)

                return new GenericCommandResult(false, "Dados de usuario inválidos!", u1.Notifications);
            // caso seja valido
            _usuarioRepositorio.Adicionar(u1);



            //      ------------- Enviar Email de boas vindas-----------

            return new GenericCommandResult(true, "Usuario Criado!", "Token");
        }
    }
}
