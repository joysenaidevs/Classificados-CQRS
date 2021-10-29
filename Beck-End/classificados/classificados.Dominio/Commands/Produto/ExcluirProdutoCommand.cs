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
    public class ExcluirProdutoCommand : Notifiable<Notification>, ICommand
    {
        // metodo construtor vazio para poder atribuir os dados do objeto
        public ExcluirProdutoCommand()
        {

        }

        public ExcluirProdutoCommand(Guid idProduto, EnStatusProduto status)
        {
            IdProduto = idProduto;
            Status = status;
        }

        public Guid IdProduto { get; set; }

        public EnStatusProduto Status { get;  set; }

        public void Validar()
        {
            //se algo nao passar nesse contrato vai retornar aqui
            AddNotifications(
               new Contract<Notification>()
                   .Requires()
                    .IsNotNull(IdProduto, "IdProduto", "o Id do Produto não pode ser null!")
                    .IsNotNull(Status, "Status", "Status não pode ser nulo!")
                  
                );
        }
    }
}
