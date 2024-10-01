using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFavoritoController : ControllerBase
    {
        private readonly IProdutoFavoritoService _produtoFavoritoService;

        public ProdutoFavoritoController(IProdutoFavoritoService produtoFavoritoService)
        {
            _produtoFavoritoService = produtoFavoritoService;
        }

        [HttpPost(Name = "AdicionarProdutoFavorito")]
        public async Task<ActionResult> Post([FromBody] ProdutoFavoritoDTO produtoFavoritoDTO)
        {
            if (produtoFavoritoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            
            await _produtoFavoritoService.AdicionarAsync(produtoFavoritoDTO);

            return CreatedAtRoute("GetProdutoFavorito", new { id =  produtoFavoritoDTO.Id }, produtoFavoritoDTO);
        }

        [HttpPut("{id}", Name = "AtualizarProdutoFavorito")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoFavoritoDTO produtoFavoritoDTO)
        {
            if (id != produtoFavoritoDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (produtoFavoritoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _produtoFavoritoService.AtualizarAsync(id, produtoFavoritoDTO);

            return Ok(produtoFavoritoDTO);
        }

        [HttpDelete("{id}", Name = "DeleteProdutoFavorito")]
        public async Task<ActionResult<ProdutoFavoritoDTO>> DeleteAsync(Guid id)
        {
            var produtoFavoritoDto = await _produtoFavoritoService.GetByIdAsync(id);
            if (produtoFavoritoDto == null)
            {
                return NotFound("Produto Favorito não encontrado");
            }
            await _produtoFavoritoService.DeleteAsync(id);

            return Ok(produtoFavoritoDto);
        }

        [HttpGet("{id}", Name = "GetProdutoFavorito")]
        public async Task<ActionResult<ProdutoFavoritoDTO>> Get(Guid id)
        {
            var produtoFavoritoDto = await _produtoFavoritoService.GetByIdAsync(id);
            if(produtoFavoritoDto == null)
            {
                return NotFound("Produto Favorito não encontrado");
            }
            return Ok(produtoFavoritoDto);
        }

        [HttpGet(Name = "GetAllProdutosFavoritos")]
        public async Task<ActionResult<IEnumerable<ProdutoFavoritoDTO>>> GetAll()
        {
            var produtosFavoritos = await _produtoFavoritoService.GetAllAsync();
            if (produtosFavoritos == null)
            {
                return NotFound("Nenhum Produto Favorito encontrado");
            }
            return Ok(produtosFavoritos);
        }
    }
}
