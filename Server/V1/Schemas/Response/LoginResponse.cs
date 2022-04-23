using Server.Entities;
using System;
using static Server.Entities.Usuario;

namespace Server.Endpoints.UsuarioForm.Response
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoAcesso Acesso { get; set; }
        public string Token { get; set; }

    }
}
