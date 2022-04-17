using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteUsuario : ControllerBase
    {
        private IRepository _repository;
        public DeleteUsuario(IRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("/Usuario/id:Guid")]
        [SwaggerOperation(
         Summary = "Deletar Usuario",
         Description = "Deletar Usuario",
         OperationId = "Usuario.DeletarUsuario",
         Tags = new[] { "UsuarioEndpoints" })
         ]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync<Usuario>(id);
                if (usuario == null) return BadRequest($"Usuario do id={id} não encontrado");
                await _repository.DeleteLogicAsync(usuario);
                return Ok($"Usuario do id={id} foi excluido com sucesso");
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
