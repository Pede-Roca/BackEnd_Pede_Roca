using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/compras-finalizadas")]
    public class ComprasFinalizadasController : ControllerBase
    {
        private readonly IComprasFinalizadasService _service;

        public ComprasFinalizadasController(IComprasFinalizadasService service)
        {
            _service = service;
        }

        [HttpPost(Name = "AdicionarCompraFinalizada")]
        public async Task<ActionResult> Post([FromBody] ComprasFinalizadasCreateDTO finalizadasDTO)
        {
            if (finalizadasDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var compraFinalizadaId = await _service.AdicionarAsync(finalizadasDTO);

            return CreatedAtRoute("GetCompraFinalizada", new { id = compraFinalizadaId }, new
            {
                id = compraFinalizadaId,
                message = "Compra Finalizada criada com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarCompraFinalizada")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ComprasFinalizadasCreateDTO finalizadasDTO)
        {
            if (finalizadasDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");

            var compraFinalizadaEncontrada = await _service.GetByIdAsync(id);
            if (compraFinalizadaEncontrada == null) return NotFound($"Compra finalizada com o ID {id} não encontrada. Verifique o ID e tente novamente!");

            await _service.AtualizarAsync(id, finalizadasDTO);
            return Ok(new { mensagem = $"Compra finalizada com o id {id} foi atualizada com sucesso" });
        }

        [HttpGet("{id}", Name = "GetCompraFinalizada")]
        public async Task<ActionResult<ComprasFinalizadasDTO>> Get(Guid id)
        {
            var finalizada = await _service.GetByIdAsync(id);
            if (finalizada == null) return NotFound("Compra finalizada não encontrada");

            return Ok(finalizada);
        }

        [HttpGet(Name = "GetAllCompraFinalizada")]
        public async Task<ActionResult<IEnumerable<ComprasFinalizadasDTO>>> GetAll()
        {
            var finalizadas = await _service.GetAllAsync();
            if (finalizadas == null) return Ok(new List<ComprasFinalizadasDTO>());

            return Ok(finalizadas);
        }

        [HttpDelete("{id}", Name = "DeleteCompraFinalizada")]
        public async Task<ActionResult<ComprasFinalizadasDTO>> DeleteAsync(Guid id)
        {
            var finalizadaEncontrada = await _service.GetByIdAsync(id);
            if (finalizadaEncontrada == null) return NotFound("Compra finalizada não encontrada");

            await _service.DeleteAsync(id);
            return Ok(new { message = "Compra finalizada removida com sucesso" });
        }
    }
}
