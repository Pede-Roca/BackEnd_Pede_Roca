using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoAssinaturaController : ControllerBase
    {
        private readonly IPlanoAssinaturaService _planoAssinaturaService;

        public PlanoAssinaturaController(IPlanoAssinaturaService planoAssinaturaService)
        {
            _planoAssinaturaService = planoAssinaturaService;
        }

        [HttpPost(Name = "AdicionarPlanoAssinatura")]
        public async Task<ActionResult> Post([FromBody] PlanoAssinaturaDTO planoAssinaturaDTO)
        {
            if (planoAssinaturaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _planoAssinaturaService.AdicionarAsync(planoAssinaturaDTO);
            return CreatedAtRoute("GetPlanoAssinatura", new { id = planoAssinaturaDTO.id }, planoAssinaturaDTO);
        }

        [HttpPut("{id}", Name = "AtualizarPlanoAssinatura")]
        public async Task<ActionResult> Put(Guid id, [FromBody]PlanoAssinaturaDTO planoAssinaturaDTO)
        {
            if ( id != planoAssinaturaDTO.id)
            {
                return BadRequest("Id não é valido");
            }

            await _planoAssinaturaService.AtualizarAsync(id, planoAssinaturaDTO);

            return Ok(planoAssinaturaDTO);
        }

        [HttpDelete("{id}", Name = "DeletePlanoAssinatura")]
        public async Task<ActionResult<PlanoAssinaturaDTO>> DeleteAsync(Guid id)
        {
            var planoAssinaturaDto = await _planoAssinaturaService.GetByIdAsync(id);
            if (planoAssinaturaDto == null)
            {
                return BadRequest("Endereço não encontrado");
            }
            await _planoAssinaturaService.DeleteAsync(id);

            return Ok(planoAssinaturaDto);
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
