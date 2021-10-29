using classificados.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Queries.Produto
{
    public class ListarMeusProdutosQuery : IQuery
    {
        
        public void Validar()
        {
           // no validations
        }

        public Guid idUsuario { get; set; }


        // criamos uma classe para mostrar somente o que é fundamental para o usuario
        public class ListarMeusProdutosResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }
            public DateTime Date { get; set; }

        }
    }
}
