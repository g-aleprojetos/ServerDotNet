using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarTodosUsuarios : ControllerBase
    {
        private IRepository _repository;
        public BuscarTodosUsuarios(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/Usuario")]
        [SwaggerOperation(
            Summary = "Buscar todos Usuarios",
            Description = "Buscar Usuarios",
            OperationId = "Usuario.BuscarTodosUsuarios",
            Tags = new[] { "UsuarioEndpoints" })
        ]
        public async Task<ActionResult<IAsyncEnumerable<UsuarioResponse>>> GetTodosUsuarios()
        {
            try
            {
                var usuarios = await _repository.ListAsync<Usuario>();                
                usuarios = usuarios.Where(x => x.Deletada != true).ToList();
                var response = usuarios.Select(x => new UsuarioResponse()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Senha = x.Senha,
                    Email = x.Email,
                }).ToList();
                return Ok(response);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
