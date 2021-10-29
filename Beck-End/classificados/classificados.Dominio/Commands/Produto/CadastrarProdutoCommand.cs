using classificados.Comum.Commands;
using classificados.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Commands.Produto
{
    public class CadastrarProdutoCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarProdutoCommand()
        {

        }

        public CadastrarProdutoCommand(string nome, string descricao, float preco, string imagem, EnStatusProduto status)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
            Status = status;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Imagem { get; set; }
        public EnStatusProduto Status { get; set; }


        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                   .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio!")
                   .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazio")
                   .IsNotEmpty(Descricao, "Descricao", "Descricao não pode ser vazio")
                   .IsNotNull(Preco, "Preco", "Preço não pode ser nulo!")
                   .IsNotNull(Status, "Status", "Status não pode ser nulo")
           );
        }
    }
}
