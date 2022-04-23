using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using static Server.Entities.Usuario;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarUsuario : ControllerBase
    {
        private IRepository _repository;
         public BuscarUsuario(IRepository repository)
        {
            _repository = repository;  
        }

        [HttpGet("/Usuario/{id:Guid}")]
        [AllowAnonymous]
        [SwaggerOperation(
         Summary = "Buscar um único Usuario",
         Description = "Buscar um único Usuario",
         OperationId = "Usuario.BuscarUsuario",
         Tags = new[] { "UsuarioEndpoints" })
         ]
        public async Task<ActionResult<UsuarioResponse>> GetUsuario(Guid id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync<Usuario>(id);
                if(usuario == null || usuario.Deletada == true) return NotFound($"Não foi encontrado o usuario do id= {id}");
                var response = new UsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                    Email = usuario.Email,
                    Acesso = usuario.Acesso,
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}

