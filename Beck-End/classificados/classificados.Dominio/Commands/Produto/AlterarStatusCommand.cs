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
    public class AlterarStatusCommand: Notifiable<Notification>, ICommand
    {

        public AlterarStatusCommand()
        {

        }

        public AlterarStatusCommand(string nome, string descricao, float preco, string imagem, EnStatusProduto status, Guid id)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
            Status = status;
            Id = id;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Imagem { get; set; }
        public EnStatusProduto Status { get; set; }
        public Guid Id { get; set; }



        public void Validar()
        {
            // se algo não passar nesse contrato, ele retorna aqui
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "Nome do produto não pode ser vazio!")
                .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazio!")
                .IsNotEmpty(Descricao, "Descricao", "Descricao não pode ser vazio!")
                .IsNotNull(Status, "Status", "Status não pode ser nulo!")
                .IsNotNull(Preco, "Preco", "Preço não pode ser nulo!")
                .IsNotNull(Id, "Id", "Id não pode ser nulo!")
            );
        }
    }
}
