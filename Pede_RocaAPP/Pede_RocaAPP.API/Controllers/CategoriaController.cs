using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost(Name = "AdicionarCategoria")]
        public async Task<ActionResult> Post([FromBody] CategoriaCreateDTO categoriaDTO)
        {
            if (categoriaDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var categoriaId = await _categoriaService.AdicionarAsync(categoriaDTO);

            return CreatedAtRoute("GetCategoria", new { id = categoriaId }, new
            {
                id = categoriaId,
                message = "Categoria criada com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarCategoria")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CategoriaCreateDTO categoriaDTO)
        {
            if (categoriaDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var categoriaEncontrada = await _categoriaService.GetByIdUpdateAsync(id);

            if (categoriaEncontrada == null) return NotFound($"Categoria com ID {id} não encontrada. Verifique o ID e tente novamente!");
            if(!string.IsNullOrEmpty(categoriaDTO.Nome)) categoriaEncontrada.Nome = categoriaDTO.Nome;
        
            await _categoriaService.AtualizarAsync(id, categoriaEncontrada);
            return Ok(new { mensagem = $"Categoria com o id {id} foi atualizada com sucesso" });
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(Guid id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound("Categoria não encontrada");

            return Ok(categoria);
        }

        [HttpGet(Name = "GetAllCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            if (categorias == null) return Ok(new List<CategoriaDTO>());

            return Ok(categorias);
        }

        [HttpDelete("{id}", Name = "DeleteCategoria")]
        public async Task<ActionResult<CategoriaDTO>> DeleteAsync(Guid id)
        {
            var categoriaDto = await _categoriaService.GetByIdAsync(id);
            if (categoriaDto == null) return NotFound("Categoria não encontrada");

            var produtosAssociados = await _categoriaService.GetByCategoriaIdAsync(id);
            if (produtosAssociados != null && produtosAssociados.Any()) return BadRequest("Não é possível excluir a categoria, pois existem produtos associados a ela.");

            await _categoriaService.DeleteAsync(id);
            return Ok(new { message = "Categoria removida com sucesso" });
        }
    }
}
