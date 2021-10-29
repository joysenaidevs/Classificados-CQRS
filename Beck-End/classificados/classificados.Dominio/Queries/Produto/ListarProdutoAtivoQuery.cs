using classificados.Comum.Enum;
using classificados.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Queries.Produto
{
    public class ListarProdutoAtivoQuery : IQuery
    {
        public EnStatusProduto? Ativo { get; set; } = null;
        public void Validar()
        {
           //sem validações
        }


        // criamos uma classe para mostrar somente o que é fundamental para o usuario
        public class ListarProdutoResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }
            public DateTime Date { get; set; }
            
        }
    }
}
