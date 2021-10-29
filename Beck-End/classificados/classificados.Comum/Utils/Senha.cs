using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Comum.Utils
{
    /// <summary>
    /// Classe estatica para criptografar uma senha
    /// Instalar pacote Bcrypt-net-core
    /// </summary>
    public static class Senha
    {
        // método de criptografar
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        //método de validar
        public static bool ValidarHashes(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }


    }
}
