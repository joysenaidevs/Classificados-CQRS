using classificados.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace classificados.Testes
{
    /// <summary>
    /// Classe de teste para Entidade Usuario
    /// </summary>
    public class UsuarioTeste
    {
        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuario = new Usuario(
              "Joyce",
              "admin@email.com",
              "123456789",
              Comum.EnTipoUsuario.Adimin

           );

 //         metodo usado para verificar que condições devem ser encontradas durante o processo
 //         de testes
            Assert.True(usuario.IsValid, "Usuario valido");
        }

        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemEmail()
        {
            Usuario usuario = new Usuario(
              "Joyce",
              "joyce.silva@",
              "123456789",
              Comum.EnTipoUsuario.Adimin

           );

            Assert.True(!usuario.IsValid, "Usuario Invalido sem Email");
        }

        // parametro pra identificar que é um teste
        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoComSenhaFraca()
        {
            Usuario usuario = new Usuario(
            "Joyce",
            "joyce.silva@gmail.com",
            "123",
            Comum.EnTipoUsuario.Adimin

         );

            Assert.True(!usuario.IsValid, "Usuario Invalido com senha fraca");
        }

    }
}
