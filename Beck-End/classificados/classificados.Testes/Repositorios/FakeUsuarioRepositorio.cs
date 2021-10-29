using classificados.Dominio;
using classificados.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
           
        }

        public void Alterar(Usuario usuario)
        {
          
        }

        public void AlterarSenha(Usuario usuario)
        {
            
        }

        public Usuario BuscarPorEmail(string email)
        {
                return null;
        }

        public Usuario BuscarPorId(Guid id)
        {
            return new Usuario("Joyce", "adm@email.com", "123456789", Comum.EnTipoUsuario.Adimin);
        }

        public ICollection<Usuario> ToList(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                 new Usuario("Joyce", "adm@email.com", "123456789", Comum.EnTipoUsuario.Adimin),
                 new Usuario("Paulo", "paulo@email.com", "123456789", Comum.EnTipoUsuario.Adimin)
            };
        }
    }
}
