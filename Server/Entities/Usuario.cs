using System;
using System.Security.Cryptography;
using System.Text;


namespace Server.Entities
{
    public class Usuario : BaseEntity
    {
        public String Nome { get; set; }
        public String Senha { get; set; }

        public Usuario(string nome, string senha, string email)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            CriadoEm = DateTime.UtcNow;
        }

        public void AtualizarUsuario(string nome, string senha, string email)
        {
            if (nome != null) Nome = nome;
            if (senha != null) Senha = senha;
            if (email != null) Email = email;
            AtualizadoEm = DateTime.UtcNow;
        }
    }
}
