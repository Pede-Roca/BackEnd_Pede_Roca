using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost(Name = "AdicionarAvaliacao")]
        public async Task<ActionResult> Post([FromBody] AvaliacaoDTO avaliacaoDTO)
        {
            if (avaliacaoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _avaliacaoService.AdicionarAsync(avaliacaoDTO);

            return CreatedAtRoute("GetAvaliacao", new { id = avaliacaoDTO.Id }, avaliacaoDTO);
        }

        [HttpPut("{id}", Name = "AtualizarAvaliacao")]
        public async Task<ActionResult> Put(Guid id, [FromBody] AvaliacaoDTO avaliacaoDTO)
        {
            if (id != avaliacaoDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (avaliacaoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _avaliacaoService.AtualizarAsync(id, avaliacaoDTO);
            return Ok(avaliacaoDTO);
        }

        [HttpDelete("{id}", Name = "DeleteAvaliacao")]
        public async Task<ActionResult<AvaliacaoDTO>> DeleteAsync(Guid id)
        {
            var avaliacaoDto = await _avaliacaoService.GetByIdAsync(id);
            if (avaliacaoDto == null)
            {
                return NotFound("Avaliacao não encontrada");
            }
            await _avaliacaoService.DeleteAsync(id);

            return Ok(avaliacaoDto);
        }

        [HttpGet("{id}", Name = "GetAvaliacao")]
        public async Task<ActionResult<AvaliacaoDTO>> Get(Guid id)
        {
            var avaliacaoDto = await _avaliacaoService.GetByIdAsync(id);
            if (avaliacaoDto == null)
            {
                return NotFound("Avaliacao não encontrada");
            }
            return Ok(avaliacaoDto);
        }

        [HttpGet(Name = "GetAllAvaliacao")]
        public async Task<ActionResult<IEnumerable<AvaliacaoDTO>>> Get()
        {
            var avaliacaoDto = await _avaliacaoService.GetAllAsync();
            if (avaliacaoDto == null)
            {
                return NotFound("Avaliacao não encontrada");
            }
            return Ok(avaliacaoDto);
        }
    }
}