using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost(Name = "AdicionarEndereco")]
        public async Task<ActionResult> Post([FromBody] EnderecoCreateDTO enderecoDTO)
        {
            if (enderecoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var enderecoId = await _enderecoService.AdicionarAsync(enderecoDTO);

            return CreatedAtRoute("GetEndereco", new { id = enderecoId }, new
            {
                id = enderecoId,
                message = "Endereço criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarEndereco")]
        public async Task<ActionResult> Put(Guid id, [FromBody] EnderecoUpdateDTO enderecoDTO)
        {
            if (enderecoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var enderecoEncontrado = await _enderecoService.GetByIdUpdateAsync(id);

            if (enderecoEncontrado == null) return NotFound($"Endereço com ID {id} não encontrado. Verifique o ID e tente novamente!");
            if (!string.IsNullOrEmpty(enderecoDTO.CEP)) enderecoEncontrado.CEP = enderecoDTO.CEP;
            if (!string.IsNullOrEmpty(enderecoDTO.Cidade)) enderecoEncontrado.Cidade = enderecoDTO.Cidade;
            if (!string.IsNullOrEmpty(enderecoDTO.Estado)) enderecoEncontrado.Estado = enderecoDTO.Estado;
            if (!string.IsNullOrEmpty(enderecoDTO.Logradouro)) enderecoEncontrado.Logradouro = enderecoDTO.Logradouro;
            if (!string.IsNullOrEmpty(enderecoDTO.Bairro)) enderecoEncontrado.Bairro = enderecoDTO.Bairro;
            if (enderecoDTO.Numero > 0) enderecoEncontrado.Numero = enderecoDTO.Numero;
            if (!string.IsNullOrEmpty(enderecoDTO.Complemento)) enderecoEncontrado.Complemento = enderecoDTO.Complemento;
        
            await _enderecoService.AtualizarAsync(id, enderecoEncontrado);

            return Ok(new { mensagem = $"Endereço com o id {id} foi atualizada com sucesso" });
        }

        [HttpGet("{id}", Name = "GetEndereco")]
        public async Task<ActionResult<EnderecoDTO>> Get(Guid id)
        {
            var enderecoDto = await _enderecoService.GetByIdAsync(id);
            if (enderecoDto == null) return NotFound("Endereço não encontrado");

            return Ok(enderecoDto);
        }

        [HttpGet("usuario/{id_usuario}", Name = "GetEnderecoPorUsuario")]
        public async Task<ActionResult<EnderecoDTO>> GetEnderecoPorUsuario(Guid id_usuario)
        {
            var enderecoDto = await _enderecoService.GetByUsuarioIdUpdateAsync(id_usuario);
            if (enderecoDto == null) return NotFound("Endereço não encontrado");
        
            return Ok(enderecoDto);
        }

        [HttpGet(Name = "GetAllEnderecos")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAll()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            if (enderecos == null || !enderecos.Any())  return Ok(new List<EnderecoDTO>());

            return Ok(enderecos);
        }

        [HttpDelete("{id}", Name = "DeleteEndereco")]
        public async Task<ActionResult<object>> DeleteAsync(Guid id)
        {
            var enderecoDto = await _enderecoService.GetByIdAsync(id);
            if (enderecoDto == null) return NotFound("Endereço não encontrado");

            await _enderecoService.DeleteAsync(id);
            return Ok(new { message = "Endereço removido com sucesso" });
        }
    }
}
