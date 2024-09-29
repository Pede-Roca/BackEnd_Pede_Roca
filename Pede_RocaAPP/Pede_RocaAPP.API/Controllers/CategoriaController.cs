using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost(Name = "AdicionarCategoria")]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _categoriaService.AdicionarAsync(categoriaDTO);

            return CreatedAtRoute("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut("{id}", Name = "AtualizarCategoria")]
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

        [HttpDelete("{id}", Name = "DeleteCategoria")]
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

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(Guid id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(categoria);
        }

        [HttpGet(Name = "GetAllCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            if (categorias == null || !categorias.Any())
            {
                return NotFound("Erro de dado inválido");
            }
            return Ok(categorias);
        }
    }
}
