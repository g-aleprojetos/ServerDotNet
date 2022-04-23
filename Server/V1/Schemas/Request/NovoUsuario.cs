using System;
using static Server.Entities.Usuario;

namespace Server.Endpoints.UsuarioForm.request
{
    public class NovoUsuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; } = "avatar nulo";
        public TipoAcesso Acesso { get; set; } = TipoAcesso.USUARIO;
    }
}
