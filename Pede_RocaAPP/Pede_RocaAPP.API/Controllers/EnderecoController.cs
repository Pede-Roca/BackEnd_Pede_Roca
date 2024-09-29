using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost(Name = "AdicionarEndereco")]
        public async Task<ActionResult> Post([FromBody] EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            
            await _enderecoService.AdicionarAsync(enderecoDTO);

            return CreatedAtRoute("GetEndereco", new { id = enderecoDTO.Id }, enderecoDTO);
        }

        [HttpPut("{id}", Name = "AtualizarEndereco")]
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

        [HttpDelete("{id}", Name = "DeleteEndereco")]
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

        [HttpGet(Name = "GetAllEnderecos")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAll()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            if (enderecos == null || !enderecos.Any())
            {
                return NotFound("Nenhum endereço encontrado");
            }

            return Ok(enderecos);
        }
    }
}
