using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.CriptografiaForm;
using Server.Endpoints.UsuarioForm.request;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Server.Endpoints.CadastroForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarCadastro : ControllerBase
    {
        private IRepository _repository;
        public CriarCadastro(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("/Cadastro")]
        [AllowAnonymous]
        [SwaggerOperation(
         Summary = "Cria um cadastro de Usuario",
         Description = "Cria cadastro de Usuario",
         OperationId = "Cadasro.Criar",
         Tags = new[] { "CadastroEndpoints" })
]
        public async Task<ActionResult<NovoUsuarioResponse>> CriarUsuario(NovoUsuario request)
        {
            try
            {
                if (request.Nome == null || request.Email == null || request.Senha == null) return BadRequest("Nome, Email e Senha tem que ser preenchido");
                var usuario = await _repository.GetByEmailAsync<Usuario>(request.Email);
                if (usuario != null)
                {
                    if (request.Email == usuario.Email && usuario.Deletada != true) return NotFound("Email já cadatrado");
                }
                var senhaCriptografada = new Criptografia();
                var usuarioNovo = new Usuario(request.Nome, senhaCriptografada.Criptografar(request.Senha), request.Email, request.Avatar, request.Acesso);
                var usuarioCriado = await _repository.AddAsync(usuarioNovo);
                return Ok(NovoUsuarioResponse.Response(usuarioCriado));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
