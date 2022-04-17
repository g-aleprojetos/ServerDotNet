using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.request;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class Criar : ControllerBase
    {
        private IRepository _repository;
        public Criar(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("/Usuario")]
        [SwaggerOperation(
            Summary = "Cria um Usuario",
            Description = "Cria Usuario",
            OperationId = "Usuario.Criar",
            Tags = new[] { "UsuarioEndpoints" })
        ]
        public async Task<ActionResult> CriarUsuario(NovoUsuario request)
        {
            try
            {
                var usuarios = await _repository.ListAsync<Usuario>();
                usuarios = usuarios.Where(x => x.Deletada != true).ToList();
                if (usuarios.Where(y => y.Email == request.Email).Any()) return BadRequest("Email já cadatrado");

                var usuario = new Usuario(request.Nome, request.Senha, request.Email);
                var usuarioCriado = await _repository.AddAsync(usuario);
                return Ok(NovoUsuarioResponse.Response(usuarioCriado));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}


