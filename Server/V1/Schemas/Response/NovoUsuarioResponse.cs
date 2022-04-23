﻿using Server.Entities;
using System;
using static Server.Entities.Usuario;

namespace Server.Endpoints.UsuarioForm.Response
{
    public class NovoUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public TipoAcesso Acesso { get; set; }

        public static NovoUsuarioResponse Response(Usuario usuario)
        {
            return new NovoUsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Email = usuario.Email,
                Avatar = usuario.Avatar,
                Acesso = usuario.Acesso,
            };
        }
    }
}
