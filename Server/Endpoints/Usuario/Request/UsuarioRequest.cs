using System;

namespace Server.Endpoints.UsuarioForm.request
{
    public class UsuarioRequest
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public string Email { get; set; }
    }
}
