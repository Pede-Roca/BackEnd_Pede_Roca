using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }

        [HttpPost(Name = "AdicionarUnidadeMedida")]
        public async Task<ActionResult> Post([FromBody] UnidadeMedidaDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _unidadeMedidaService.AdicionarAsync(unidadeMedidaDTO);

            return CreatedAtRoute("GetUnidadeMedida", new { id = unidadeMedidaDTO.Id }, unidadeMedidaDTO);
        }

        [HttpPut("{id}", Name = "AtualizarUnidadeMedida")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UnidadeMedidaDTO unidadeMedidaDTO)
        {
            if (id != unidadeMedidaDTO.Id)
            {
                return BadRequest("Id não é válido");
            }
            if (unidadeMedidaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _unidadeMedidaService.AtualizarAsync(id, unidadeMedidaDTO);

            return Ok(unidadeMedidaDTO);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteUnidadeMedida")]
        public async Task<ActionResult<UnidadeMedidaDTO>> DeleteAsync(Guid id)
        {
            var unidadeMedidaDto = await _unidadeMedidaService.GetByIdAsync(id);
            if (unidadeMedidaDto == null)
            {
                return NotFound("Unidade de medida não encontrada");
            }
            await _unidadeMedidaService.DeletarAsync(id);

            return Ok(unidadeMedidaDto);
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
