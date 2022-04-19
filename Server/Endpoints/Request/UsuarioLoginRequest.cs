using System;

namespace Server.Endpoints.UsuarioForm.request
{
    public class UsuarioLoginRequest
    {
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
