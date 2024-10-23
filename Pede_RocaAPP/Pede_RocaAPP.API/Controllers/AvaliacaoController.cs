using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    // [Authorize(Roles = "adm")]
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost(Name = "AdicionarAvaliacao")]
        public async Task<ActionResult> Post([FromBody] AvaliacaoCreateDTO avaliacaoDTO)
        {
            if (avaliacaoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var avaliacaoId = await _avaliacaoService.AdicionarAsync(avaliacaoDTO);

            return CreatedAtRoute("GetAvaliacao", new { id = avaliacaoId }, new { id = avaliacaoId, message = "Avaliação criada com sucesso"});
        }
        
        [HttpPut("{id}", Name = "AtualizarAvaliacao")]
        public async Task<ActionResult> Put(Guid id, [FromBody] AvaliacaoUpdateDTO avaliacaoDTO)
        {
            if (avaliacaoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");

            var avaliacaoEncontrada = await _avaliacaoService.GetByIdUpdateAsync(id);

            if (avaliacaoEncontrada == null) return NotFound($"Avaliação com ID {id} não encontrada. Verifique o ID e tente novamente!");
            if (avaliacaoDTO.Nota >= 0 && avaliacaoDTO.Nota <= 5) avaliacaoEncontrada.Nota = avaliacaoDTO.Nota;
            if (!string.IsNullOrEmpty(avaliacaoDTO.Descricao)) avaliacaoEncontrada.Descricao = avaliacaoDTO.Descricao;
            
            await _avaliacaoService.AtualizarAsync(id, avaliacaoEncontrada);

            return Ok(new { mensagem = $"Avaliação com o id {id} foi atualizada com sucesso"});
        }

        [HttpGet("{id}", Name = "GetAvaliacao")]
        public async Task<ActionResult<AvaliacaoDTO>> Get(Guid id)
        {
            var avaliacaoDto = await _avaliacaoService.GetByIdAsync(id);
            if (avaliacaoDto == null) return NotFound("Avaliacao não encontrada");
            
            return Ok(avaliacaoDto);
        }

        [HttpGet(Name = "GetAllAvaliacao")]
        public async Task<ActionResult<IEnumerable<AvaliacaoDTO>>> Get()
        {
            var avaliacaoDto = await _avaliacaoService.GetAllAsync();
            if (avaliacaoDto == null) return Ok(new List<AvaliacaoDTO>());

            return Ok(avaliacaoDto);
        }

        [HttpDelete("{id}", Name = "DeleteAvaliacao")]
        public async Task<ActionResult<AvaliacaoDTO>> DeleteAsync(Guid id)
        {
            var avaliacaoDto = await _avaliacaoService.GetByIdAsync(id);
            if (avaliacaoDto == null) return NotFound("Avaliacao não encontrada");

            await _avaliacaoService.DeleteAsync(id);

            return Ok(new { message = "Avaliação removida com sucesso" });
        }
    }
}