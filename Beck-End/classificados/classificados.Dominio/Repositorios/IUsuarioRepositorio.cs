 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Dominio.Repositorios
{
    /// <summary>
    /// Repositorio responsavel por Usuario
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto que será adicionado</param>
        void Adicionar(Usuario usuario);

        /// <summary>
        /// Altera um usuario existente
        /// </summary>
        /// <param name="usuario">objeto que será alterado</param>
        void Alterar(Usuario usuario);

        /// <summary>
        /// Altera a senha de usuario
        /// </summary>
        /// <param name="usuario">objeto que será alterado</param>
        //void AlterarSenha(Usuario usuario);

        /// <summary>
        /// Busca um usuario através do seu email
        /// </summary>
        /// <param name="email">objeto que será buscado</param>
        /// <returns>retorna um usuario buscado através do seu email</returns>
        Usuario BuscarPorEmail(string email);

        /// <summary>
        /// Busca um usuario através do seu id
        /// </summary>
        /// <param name="id">id que será buscado</param>
        /// <returns>retorna o usuario buscado atravpes do seu id</returns>
        Usuario BuscarPorId(Guid id);


       /// <summary>
       /// Lista todos os usuarios
       /// bool? => verifica o que ta vazio
       /// </summary>
       /// <param name="ativo">objeto que será listado</param>
       /// <returns>retorna somente os usuarios ativos</returns>
        ICollection<Usuario> ToList(bool? ativo = null);
    }
}
