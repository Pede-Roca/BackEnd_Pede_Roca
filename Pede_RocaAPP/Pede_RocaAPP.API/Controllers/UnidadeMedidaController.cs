using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }

        [HttpPost(Name = "AdicionarUnidadeMedida")]
        public async Task<ActionResult> Post([FromBody] UnidadeMedidaCreateDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var unidadeMedidaId = await _unidadeMedidaService.AdicionarAsync(unidadeMedidaDTO);

            return CreatedAtRoute("GetUnidadeMedida", new { id = unidadeMedidaId }, new
            {
                id = unidadeMedidaId,
                message = "Unidade de medida criada com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarUnidadeMedida")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UnidadeMedidaCreateDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var unidadeMedidaEncontrado = await _unidadeMedidaService.GetByIdUpdateAsync(id);

            if(unidadeMedidaEncontrado == null)
            {
                return NotFound($"Unidade de medida com ID {id} não encontrada. Verifique o ID e tente novamente!");
            }

            if(unidadeMedidaEncontrado.SiglaUnidade != unidadeMedidaDTO.SiglaUnidade)
            {
                unidadeMedidaEncontrado.SiglaUnidade = unidadeMedidaDTO.SiglaUnidade;
            }

            if (unidadeMedidaEncontrado.NomeUnidade != unidadeMedidaDTO.NomeUnidade)
            {
                unidadeMedidaEncontrado.NomeUnidade = unidadeMedidaDTO.NomeUnidade;
            }

            await _unidadeMedidaService.AtualizarAsync(id, unidadeMedidaEncontrado);

            return Ok(new
            {
                mensagem = $"Unidade de medida com o id {id} foi atualizada com sucesso"
            });
        }

        [HttpDelete("{id:Guid}", Name = "DeleteUnidadeMedida")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<UnidadeMedidaDTO>> DeleteAsync(Guid id)
        {
            var unidadeMedidaDto = await _unidadeMedidaService.GetByIdAsync(id);
            if (unidadeMedidaDto == null)
            {
                return NotFound("Unidade de medida não encontrada");
            }
            await _unidadeMedidaService.DeletarAsync(id);

            return Ok(new
            {
                message = "Unidade de medida removida com sucesso"
            });
        }

        [HttpGet("{id}", Name = "GetUnidadeMedida")]
        public async Task<ActionResult<UnidadeMedidaDTO>> Get(Guid id)
        {
            var unidadeMedida = await _unidadeMedidaService.GetByIdAsync(id);
            if (unidadeMedida == null)
            {
                return NotFound("Unidade de medida não encontrada");
            }
            return Ok(unidadeMedida);
        }

        [HttpGet(Name = "GetAllUnidadesMedida")]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaDTO>>> GetAll()
        {
            var unidades = await _unidadeMedidaService.GetAllAsync();
            if (unidades == null || !unidades.Any())
            {
                return NotFound("Nenhuma unidade de medida encontrada");
            }
            return Ok(unidades);
        }
    }
}
