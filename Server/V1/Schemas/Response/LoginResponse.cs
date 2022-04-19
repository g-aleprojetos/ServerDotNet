using Server.Entities;
using System;

namespace Server.Endpoints.UsuarioForm.Response
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

    }
}
