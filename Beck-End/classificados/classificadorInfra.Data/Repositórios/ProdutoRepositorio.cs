using classificados.Comum.Enum;
using classificados.Dominio;
using classificados.Dominio.Entidades;
using classificados.Dominio.Repositorios;
using classificados.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Infra.Data.Repositórios
{
    /// <summary>
    /// Repositorio responsavel por Produto
    /// </summary>
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        // injecao de dependencia
        private readonly classificadosContext _context;

        //metdo construtor
        public ProdutoRepositorio(classificadosContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Altera um produto existente
        /// </summary>
        /// <param name="produto">objeto que será alterado</param>
        public void Alterar(Produto produto)
        {
            // Entry -> pegar as entradas do usuarios
            // state -> pegar os estados das entradas e verificar se foi modificado
            // EntityState -> Enum do entity framework
           
            //_context.Entry(produto).State = EntityState.Modified;
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

       

        public void AlterarStatus(EnStatusProduto statusProduto)
        {
            // Entry -> pegar as entradas do usuarios
            // state -> pegar os estados das entradas e verificar se foi modificado
            // EntityState -> Enum do entity framework

            _context.Entry(statusProduto).State = EntityState.Modified;
            //_context.Produtos.Add(statusProduto);
            _context.SaveChanges();
        }

        public Produto BuscarPorId(Guid id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Busca um produto pelo nome
        /// </summary>
        /// <param name="nome">objeto que será buscado</param>
        /// <returns>retorna todos os produtos pelo nome</returns>
        public Produto BuscarPorNome(string nome)
        {
      
            return _context.Produtos.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="produto">objeto que será cadastrado</param>
        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

       

        /// <summary>
        /// Deleta um produto atraves do seu id
        /// </summary>
        /// <param name="id">objeto que será deletado</param>
        public void Deletar(Guid id)
        {
            Produto item = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Lista todos os produtos ativos
        /// </summary>
        /// <param name="ativo">objeto q será listaod</param>
        /// <returns>retorna uma lista de produtos ativos</returns>
        public IEnumerable<Produto> Listar(EnStatusProduto? ativo = null)
        {
            if (ativo == null)
            {
                return _context.Produtos
                    .AsNoTracking()
                    .OrderBy(p => p.Date);

            }
            else
            {
                return _context.Produtos
                    .AsNoTracking()
                    .Where(p => p.Status == ativo)
                    .OrderBy(p => p.Date);
            }
        }

        
        /// <summary>
        /// lista o produto de um determinado usuario
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public List<Produto> ListarMinhas(Guid idUsuario)
        {
            // listar o comentario de um determinado pacote
            return _context.Produtos
                .AsNoTracking()
                .OrderBy(p => p.Date)
                .Where(p => p.Id == idUsuario)
                .ToList();
        }

    }
}
