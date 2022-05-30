using Microsoft.AspNetCore.Mvc;
using Server.CriptografiaForm;
using Server.Endpoints.UsuarioForm.request;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Server.Endpoints.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarUsuarioPorEmail : ControllerBase
    {
        private IRepository _repository;
        public BuscarUsuarioPorEmail(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("/Login")]
        [SwaggerOperation(
         Summary = "Buscar Usuario pelo nome",
         Description = "Buscar um único Usuario pelo nome",
         OperationId = "Login.BuscarUsuario",
         Tags = new[] { "LoginEndpoints" })
         ]
        public async Task<ActionResult<LoginResponse>> GetUsuarioPorEmail(UsuarioLoginRequest request)
        {
            try
            {
                var usuario = await _repository.GetByEmailAsync<Usuario>(request.Email);
                if (usuario == null || usuario.Deletada == true) return NotFound($"Não foi encontrado o usuario do Email= {request.Email}");

                var senhaCriptografada = new Criptografia();
                if (usuario.Senha == senhaCriptografada.Criptografar(request.Senha))
                {
                    var response = new LoginResponse
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Senha errada");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
