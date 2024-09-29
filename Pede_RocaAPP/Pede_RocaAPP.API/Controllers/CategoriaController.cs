using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.API.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService ICategoriaService)
        {
            _categoriaService = ICategoriaService;
        }

        [HttpPost(Name = "AdicionarAsync")]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _categoriaService.AdicionarAsync(categoriaDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut(Name = "AtualizarAsync")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (categoriaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _categoriaService.AtualizarAsync(id, categoriaDTO);

            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:Guid", Name = "DeleteAsync")]
        public async Task<ActionResult<CategoriaDTO>> DeleteAsync(Guid id)
        {
            var categoriaDto = await _categoriaService.GetByIdAsync(id);
            if (categoriaDto == null)
            {
                return NotFound("Categoria não encontrada");
            }
            await _categoriaService.DeleteAsync(id);

            return Ok(categoriaDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<CategoriaDTO>> Get(Guid id)
        {
            var produto = await _categoriaService.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound("produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var produtos = await _categoriaService.GetAllAsync();
            if (produtos == null) { return NotFound("Erro de dado inválido"); }
            return Ok(produtos);
        }
    }
}
