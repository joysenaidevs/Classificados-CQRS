using classificados.Dominio;
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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // injecao de dependencia
        private readonly classificadosContext _context;

        //metdo construtor
        public UsuarioRepositorio(classificadosContext contexto)
        {
            _context = contexto;
        }

        /// <summary>
        /// Adiciona um novo usuario
        /// </summary>
        /// <param name="usuario">objeto que será adicionado</param>
        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Altera um usuarioe existente
        /// </summary>
        /// <param name="usuario">objeto que será alterado</param>
        public void Alterar(Usuario usuario)
        {
            // Entry -> pegar as entradas do usuarios
            // state -> pegar os estados das entradas e verificar se foi modificado
            // EntityState -> Enum do entity framework

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario através do seu email
        /// </summary>
        /// <param name="email">objeto que será buscado</param>
        /// <returns>retorna todos os usuarios buscados</returns>
        public Usuario BuscarPorEmail(string email)
        {

            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }


        /// <summary>
        /// Busca um usuario atrávés do seu ID
        /// </summary>
        /// <param name="id">objeto que será buscado</param>
        /// <returns>retorna um usuario buscado</returns>
        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Lista todos os usuarios ativos
        /// </summary>
        /// <param name="ativo">objeto que vai listar os usuarios ativos</param>
        /// <returns>retorna todos os usuarios ativos</returns>
        public ICollection<Usuario> ToList(bool? ativo = null)
        {
            return _context.Usuarios
                .AsNoTracking() // pegar os dados que são somente leitura, não armazenados em cache DbContext
                //.Include(x => x.)
                .OrderBy(x => x.Date)
                .ToList();
        }
    }
}
