using classificados.Comum.Enum;
using classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Repositorios
{
    public interface IProdutoRepositorio
    {
       /// <summary>
       /// Cadastra um novo Produto
       /// </summary>
       /// <param name="produto">objeto que será cadastrado</param>
        void Cadastrar(Produto produto);

       /// <summary>
       /// Altera um produto existente
       /// </summary>
       /// <param name="produto">objeto que será alterado</param>
        void Alterar( Produto produto);

        /// <summary>
        /// Altera o status de um produto
        /// </summary>
        /// <param name="statusProduto">objeto que será alterado</param>
        void AlterarStatus( EnStatusProduto statusProduto);
      
        /// <summary>
        /// busca um produto
        /// </summary>
        /// <param name="nome">objeto que sera buscado</param>
        /// <returns>retorna um produto buscado pelo nome</returns>
        Produto BuscarPorNome(string nome);

        /// <summary>
        /// Busca um usuario através do seu id
        /// </summary>
        /// <param name="id">id que será buscado</param>
        /// <returns>retorna o usuario buscado atravpes do seu id</returns>
        Produto BuscarPorId(Guid id);


        /// <summary>
        /// Lista todos os produtos
        /// bool? => verifica o que ta vazio
        /// </summary>
        /// <param name="ativo">objeto que será listado</param>
        /// <returns>retorna somente os prdutos ativos</returns>
        public IEnumerable<Produto> Listar(EnStatusProduto? ativo = null);

        /// <summary>
        /// Lista o produto de um determinado usuario
        /// </summary>
        /// <param name="id">objeto q sera listado</param>
        /// <returns>retorna o produto listado de um determinado usuario</returns>
        public List<Produto> ListarMinhas(Guid idUsuario);

        /// <summary>
        /// Deleta um produto existente
        /// </summary>
        /// <param name="id">objeto que será deletado</param>
        void Deletar(Guid id);



    }
}
