using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.CriptografiaForm;
using Server.Endpoints.UsuarioForm.request;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarUsuario : ControllerBase
    {
        private IRepository _repository;
        public AtualizarUsuario(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("/Usuario/id:Guid")]
        [SwaggerOperation(
         Summary = "Atualiza Usuario",
         Description = "Atualiza Usuario",
         OperationId = "Usuario.AtualizaUsuario",
         Tags = new[] { "UsuarioEndpoints" })
         ]
        public async Task<ActionResult<UsuarioResponse>> Atualizar(UsuarioRequest request)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync<Usuario>(request.Id);
                if (usuario == null || usuario.Deletada == true) return NotFound($"Não foi encontrado o usuario do id= {request.Id}");

                var senhaCriptografada = new Criptografia();

                usuario.AtualizarUsuario(request.Nome, senhaCriptografada.Criptografar(request.Senha), request.Email);
                await _repository.UpdateAsync(usuario);
                var response = new UsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                    Email = usuario.Email,
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

