using classificados.Comum;
using classificados.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio
{
    /// <summary>
    /// herdamos a referencia de projeto para classificados.Comum da super
    /// classe base
    /// garantir que esta classe Usuario esteja fechada para modficacoes e aberta para extensões
    /// (colocar set como private)
    /// </summary>


    public class Usuario : Base
    {

        //método construtor, obrigamos que a classe seja instanciada
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            //se algo nao passar nesse contrato vai retornar aqui
             AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio!")
                    .IsEmail(email, "Email", "O formato do email está incorreto!")
                    .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos  8 caracteres")
            );

            if (IsValid)
            {

                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
        public bool Isvalid { get;  private set; }

        //composição (caso precise)
        public IReadOnlyCollection<Produto> Produtos { get; private set; }


        // manipulação
        public void AtualizaSenha(string senha)
        {
            // se algo não passar nesse contrato, ele retorna aqui
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos  8 caracteres")
            );

            // se for valido
            if (IsValid)
            {
                Senha = senha;
            }

        }

        // Manipulação de dados
        public void AtualizaUsuario(string nome, string email)
        {

            // se algo não passar nesse contrato, ele retorna aqui
            AddNotifications(
            new Contract<Notification>()
               .Requires()
               .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio!")
               .IsEmail(email, "Email", "O formato do email está incorreto!")

            );

            // se for valido
            if (IsValid)
            {

                Nome = nome;
                Email = email;

            }
        }
    }
}
