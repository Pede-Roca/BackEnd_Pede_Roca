using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemService _mensagemService;

        public MensagemController(IMensagemService mensagemService)
        {
            _mensagemService = mensagemService;
        }

        [HttpPost(Name = "AdicionarMensagem")]
        public async Task<ActionResult> Post([FromBody] MensagemDTO mensagemDTO)
        {
            if (mensagemDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _mensagemService.AdicionarAsync(mensagemDTO);

            return CreatedAtRoute("GetMensagem", new { id = mensagemDTO.Id }, mensagemDTO);
        }

        [HttpPut("{id}", Name = "AtualizarMensagem")]
        public async Task<ActionResult> Put(Guid id, [FromBody] MensagemDTO mensagemDTO)
        {
            if (id != mensagemDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (mensagemDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _mensagemService.AtualizarAsync(id, mensagemDTO);
            return Ok(mensagemDTO);
        }

        [HttpDelete("{id}", Name = "DeleteMensagem")]
        public async Task<ActionResult<MensagemDTO>> DeleteAsync(Guid id)
        {
            var mensagemDto = await _mensagemService.GetByIdAsync(id);
            if (mensagemDto == null)
            {
                return NotFound("Mensagem não encontrada");
            }
            await _mensagemService.DeleteAsync(id);

            return Ok(mensagemDto);
        }

        [HttpGet("{id}", Name = "GetMensagem")]
        public async Task<ActionResult<MensagemDTO>> Get(Guid id)
        {
            var mensagemDto = await _mensagemService.GetByIdAsync(id);
            if (mensagemDto == null)
            {
                return NotFound("Mensagem não encontrada");
            }
            return Ok(mensagemDto);
        }

        [HttpGet(Name = "GetMensagens")]
        public async Task<ActionResult<IEnumerable<MensagemDTO>>> Get()
        {
            var mensagens = await _mensagemService.GetAllAsync();
            if (mensagens == null)
            {
                return NotFound("Nenhuma mensagem encontrada");
            }
            return Ok(mensagens);
        }
    }
}