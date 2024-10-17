using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/plano-assinatura")]
    public class PlanoAssinaturaController : ControllerBase
    {
        private readonly IPlanoAssinaturaService _planoAssinaturaService;

        public PlanoAssinaturaController(IPlanoAssinaturaService planoAssinaturaService)
        {
            _planoAssinaturaService = planoAssinaturaService;
        }

        [HttpPost(Name = "AdicionarPlanoAssinatura")]
        public async Task<ActionResult> Post([FromBody] PlanoAssinaturaCreateDTO planoAssinaturaDTO)
        {
            if (planoAssinaturaDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var planoAssinaturaId = await _planoAssinaturaService.AdicionarAsync(planoAssinaturaDTO);

            return CreatedAtRoute("GetPlanoAssinatura", new { id = planoAssinaturaId }, new
            {
                id = planoAssinaturaId,
                message = "Avaliação criada com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarPlanoAssinatura")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PlanoAssinaturaUpdateDTO planoAssinaturaDTO)
        {
            if (planoAssinaturaDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var planoAssinaturaEncontrado = await _planoAssinaturaService.GetByIdUpdateAsync(id);

            if (planoAssinaturaEncontrado == null)
            {
                return NotFound($"Plano de assinatura com ID {id} não encontrado. Verifique o ID e tente novamente!");
            }

            if(planoAssinaturaDTO.preco > 0)
            {
                planoAssinaturaEncontrado.preco = planoAssinaturaDTO.preco;
            }

            if(planoAssinaturaDTO.Ativo != planoAssinaturaEncontrado.Ativo)
            {
                planoAssinaturaEncontrado.Ativo = planoAssinaturaDTO.Ativo;
            }

            await _planoAssinaturaService.AtualizarAsync(id, planoAssinaturaEncontrado);

            return Ok(new
            {
                mensagem = $"Plano de assinatura com o id {id} foi atualizada com sucesso"
            });
        }

        [HttpDelete("{id}", Name = "DeletePlanoAssinatura")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<PlanoAssinaturaDTO>> DeleteAsync(Guid id)
        {
            var planoAssinaturaDto = await _planoAssinaturaService.GetByIdAsync(id);

            if (planoAssinaturaDto == null)
            {
                return BadRequest("Endereço não encontrado");
            }
            await _planoAssinaturaService.DeleteAsync(id);

            return Ok(new
            {
                message = "Plano de assinatura removida com sucesso"
            });
        }

        [HttpGet("{id}", Name = "GetPlanoAssinatura")]
        public async Task<ActionResult<PlanoAssinaturaDTO>> Get(Guid id)
        {
            var planoAssinaturaDto = await _planoAssinaturaService.GetByIdAsync(id);
            if ( planoAssinaturaDto == null)
            {
                return NotFound("Endereço não encontrado");
            }

            return Ok(planoAssinaturaDto);
        }

        [HttpGet(Name = "GetAllPlanoAssinatura")]
        public async Task<ActionResult<IEnumerable<PlanoAssinaturaDTO>>> GetAll()
        {
            var planosAssinaturas = await _planoAssinaturaService.GetAllAsync();
            if (planosAssinaturas == null || !planosAssinaturas.Any())
            {
                return NotFound("Nenhum plano de assinatura encontrado");
            }

            return Ok(planosAssinaturas);
        }
    }
}
