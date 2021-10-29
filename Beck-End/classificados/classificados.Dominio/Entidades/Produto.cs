using classificados.Comum;
using classificados.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Entidades
{
    public class Produto : Base
    {
        public Produto(string nome,string descricao, string imagem, float preco, EnStatusProduto status)
        {
            // se algo não passar nesse contrato, ele retorna aqui
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome do produto não pode ser vazio!")
                .IsNotEmpty(descricao, "Descricao", "Descricao não pode ser vazio!")
                .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazio!")
                .IsNotNull(preco, "Preco", "Preço não pode ser nulo!")
                .IsNotNull(status, "Status", "Status não pode ser nulo!")

                 
            );

            if (IsValid)
            {
           
                Nome = nome;
                Descricao = descricao;
                Imagem = imagem;
                Preco = preco;
                Status = status;
              
                
                
            }

        }

        
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public float Preco { get; private set; }
        public EnStatusProduto Status { get; private set; }

        //composições (caso precise)
        // Composições
        //public Guid IdUsuario { get; private set; }
    }
}
