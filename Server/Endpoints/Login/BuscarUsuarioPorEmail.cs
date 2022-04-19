using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.request;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
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
         OperationId = "Usuario.BuscarUsuario",
         Tags = new[] { "LoginEndpoints" })
         ]
        public async Task<ActionResult> GetUsuarioPorEmail( UsuarioLoginRequest request)
        {
            try
            {
                var usuario = await _repository.GetByEmailAsync<Usuario>(request.Email);
                if (usuario == null) return NotFound();


                //        var usuarios = await _repository.ListAsync<Usuario>();
                //        usuarios = usuarios.Where(x => x.Deletada != true).ToList();


                //       // if (usuarios == null || usuarios.Deletada == true) return NotFound($"Não foi encontrado o usuario do Email= {request.Email}");
                //        //var response = new UsuarioResponse
                //        //{
                //        //    Id = usuario.Id,
                //        //    Nome = usuario.Nome,
                //        //    Senha = usuario.Senha,
                //        //    Email = usuario.Email,
                //        //};

                return Ok();
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
