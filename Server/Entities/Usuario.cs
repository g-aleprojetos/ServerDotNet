using System;
using System.Security.Cryptography;
using System.Text;


namespace Server.Entities
{
    public class Usuario : BaseEntity
    {
        public String Nome { get; set; }
        public String Senha { get; set; }
        public String Avatar { get; set; }
        public TipoAcesso Acesso { get; private set; }

        public Usuario(TipoAcesso acesso)
        {
            Acesso = acesso;
        }

        public Usuario(string nome, string senha, string email, string avatar, TipoAcesso acesso)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Acesso = acesso;    
            Avatar = avatar;
            CriadoEm = DateTime.UtcNow;
        }

        public void AtualizarUsuario(string nome, string senha, string email,string avatar, TipoAcesso acesso)
        {
            if (nome != null) Nome = nome;
            if (senha != null) Senha = senha;
            if (email != null) Email = email;
            if (avatar != null) Avatar = avatar;
            Acesso = acesso;
            AtualizadoEm = DateTime.UtcNow;
        }

        public enum TipoAcesso
        {
            ADM,
            USUARIO,
            NULO
        }
    }
}
