using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService IEnderecoService)
        {
            _enderecoService = IEnderecoService;
        }

        [HttpPost(Name = "AdicionarAsync")]
        public async Task<ActionResult> Post([FromBody] EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            
            await _enderecoService.AdicionarAsync(enderecoDTO);

            return new CreatedAtRouteResult("GetEndereco", new { id = enderecoDTO.Id }, enderecoDTO);
        }

        [HttpPut(Name = "AtualizarAsync")]
        public async Task<ActionResult> Put(Guid id, [FromBody] EnderecoDTO enderecoDTO)
        {
            if (id != enderecoDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (enderecoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _enderecoService.AtualizarAsync(id, enderecoDTO);

            return Ok(enderecoDTO);
        }

        [HttpDelete("{id:Guid", Name = "DeleteAsync")]
        public async Task<ActionResult<EnderecoDTO>> DeleteAsync(Guid id)
        {
            var enderecoDto = await _enderecoService.GetByIdAsync(id);
            if (enderecoDto == null)
            {
                return NotFound("Endereço não encontrado");
            }
            await _enderecoService.DeleteAsync(id);

            return Ok(enderecoDto);
        }

        [HttpGet("{id}", Name = "GetEndereco")]
        public async Task<ActionResult<EnderecoDTO>> Get(Guid id)
        {
            var enderecoDto = await _enderecoService.GetByIdAsync(id);
            if (enderecoDto == null)
            {
                return NotFound("Endereço não encontrado");
            }

            return Ok(enderecoDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Get()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            if (enderecos == null)
            {
                return NotFound("Endereços não encontrados");
            }

            return Ok(enderecos);
        }
    }
}