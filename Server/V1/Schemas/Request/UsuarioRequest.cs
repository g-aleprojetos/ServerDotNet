using System;
using static Server.Entities.Usuario;

namespace Server.Endpoints.UsuarioForm.request
{
    public class UsuarioRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public TipoAcesso Acesso { get; set; } = TipoAcesso.NULO;
    }
}
