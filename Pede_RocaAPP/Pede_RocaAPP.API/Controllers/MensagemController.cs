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
    [Route("api/mensagem")]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemService _mensagemService;
        private readonly IUsuarioService _usuarioService;

        public MensagemController(IMensagemService mensagemService, IUsuarioService usuarioService)
        {
            _mensagemService = mensagemService;
            _usuarioService = usuarioService;
        }

        [HttpPost(Name = "AdicionarMensagem")]
        public async Task<ActionResult> Post([FromBody] MensagemCreateDTO mensagemDTO)
        {
            if (mensagemDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }


            var mensagemId = await _mensagemService.AdicionarAsync(mensagemDTO);

            return CreatedAtRoute("GetMensagem", new { id = mensagemId }, new
            {
                id = mensagemId,
                message = "Mensagem criada com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarMensagem")]
        public async Task<ActionResult> Put(Guid id, [FromBody] MensagemUpdateDTO mensagemDTO)
        {
            if (mensagemDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var mensagemEncontrada = await _mensagemService.GetByIdUpdateAsync(id);

            if (!string.IsNullOrEmpty(mensagemDTO.Email))
            {
                mensagemEncontrada.Email = mensagemDTO.Email;
            }

            if (!string.IsNullOrEmpty(mensagemDTO.Conteudo))
            {
                mensagemEncontrada.Conteudo = mensagemDTO.Conteudo;
            }

            if (!string.IsNullOrEmpty(mensagemDTO.UidAnexo))
            {
                mensagemEncontrada.UidAnexo = mensagemDTO.UidAnexo;
            }

            if (!string.IsNullOrEmpty(mensagemDTO.Status))
            {
                mensagemEncontrada.Status = mensagemDTO.Status;
            }

            await _mensagemService.AtualizarAsync(id, mensagemEncontrada);

            return Ok(new
            {
                mensagem = $"Mensagem com o id {id} foi atualizada com sucesso"
            });
        }

        [HttpDelete("{id}", Name = "DeleteMensagem")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<MensagemDTO>> DeleteAsync(Guid id)
        {
            var mensagemDto = await _mensagemService.GetByIdAsync(id);

            if (mensagemDto == null)
            {
                return NotFound("Mensagem não encontrada");
            }

            await _mensagemService.DeleteAsync(id);

            return Ok(new
            {
                message = "Mensagem removida com sucesso"
            });
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