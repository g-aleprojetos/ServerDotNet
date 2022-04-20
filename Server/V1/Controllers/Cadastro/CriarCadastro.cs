using Microsoft.AspNetCore.Mvc;
using Server.CriptografiaForm;
using Server.Endpoints.UsuarioForm.request;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
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
                var usuario = await _repository.ListAsync<Usuario>();
                usuario = usuario.Where(x => x.Deletada != true).ToList();
                if (usuario.Where(y => y.Email == request.Email).Any()) return BadRequest("Email já cadatrado");

                var senhaCriptografada = new Criptografia();
                var usuarioNovo = new Usuario(request.Nome, senhaCriptografada.Criptografar(request.Senha), request.Email);
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
