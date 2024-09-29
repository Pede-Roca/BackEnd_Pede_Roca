using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService IunidadeMedidaService)
        {
            _unidadeMedidaService = IunidadeMedidaService;
        }

        [HttpPost(Name = "AdicionarAsync")]
        public async Task<ActionResult> Post([FromBody] UnidadeMedidaDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _unidadeMedidaService.AdicionarAsync(unidadeMedidaDTO);

            return new CreatedAtRouteResult("GetUnidadeMedida", new { id = unidadeMedidaDTO.Id }, unidadeMedidaDTO);
        }

        [HttpPut(Name = "AtualizarAsync")]
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

        [HttpDelete("{id:Guid", Name = "DeleteAsync")]
        public async Task<ActionResult<UnidadeMedidaDTO>> DeleteAsync(Guid id)
        {
            var unidadeMedidaDto = await _unidadeMedidaService.GetByIdAsync(id);
            if (unidadeMedidaDto == null)
            {
                return NotFound("Unidade de medida não encontrado");
            }
            await _unidadeMedidaService.DeletarAscyn(id);

            return Ok(unidadeMedidaDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<UnidadeMedidaDTO>> Get(Guid id)
        {
            var unidadeMedida = await _unidadeMedidaService.GetByIdAsync(id);
            if(unidadeMedida == null)
            {
                return NotFound("Unidade de medida não encontrada");
            }
            return Ok(unidadeMedida);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaDTO>>> Get()
        {
            var unidades = await _unidadeMedidaService.GetAllAsync();
            if (unidades == null)
            {
                return NotFound("Erro de dado inválido");
            }
            return Ok(unidades);
        }
    }
}
