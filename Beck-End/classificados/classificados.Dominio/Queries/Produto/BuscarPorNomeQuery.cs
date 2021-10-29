using classificados.Comum.Enum;
using classificados.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Queries.Produto
{
    public class BuscarPorNomeQuery : IQuery
    {
        public void Validar()
        {
            // sem validações
        }

        public string Nome { get; set; }
        public string Descricao { get;  set; }
        public float Preco { get;  set; }
        public string Imagem { get;  set; }
        public EnStatusProduto Status { get;  set; }

        public class BuscarPorNomeResult
        {
         
            public string Nome { get; set; }
            public string Descricao { get;  set; }
            public float Preco { get;  set; }
            public string Imagem { get;  set; }
            public EnStatusProduto Status { get; set; }

        }


    }
}
