using System;

namespace Server.Endpoints.UsuarioForm.request
{
    public class UsuarioRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
