using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

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
        public async Task<ActionResult> Post([FromBody] ProdutoFavoritoCreateDTO produtoFavoritoDTO)
        {
            if (produtoFavoritoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var produtoFavoritosId = await _produtoFavoritoService.AdicionarAsync(produtoFavoritoDTO);

            return CreatedAtRoute("GetProdutoFavorito", new { id = produtoFavoritosId }, new
            {
                id = produtoFavoritosId,
                message = "Produtos favoritos criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarProdutoFavorito")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoFavoritoCreateDTO produtoFavoritoDTO)
        {
            if (produtoFavoritoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var produtoFavoritoEncontrado = await _produtoFavoritoService.GetByIdUpdateAsync(id);

            if (produtoFavoritoEncontrado == null)
            {
                return NotFound($"Produto favorito com ID {id} não encontrada. Verifique o ID e tente novamente!");
            }

            if(produtoFavoritoDTO.IdProduto != produtoFavoritoEncontrado.IdProduto)
            {
                produtoFavoritoEncontrado.IdProduto = produtoFavoritoDTO.IdProduto;
            }

            if (produtoFavoritoDTO.IdUsuario != produtoFavoritoEncontrado.IdUsuario)
            {
                produtoFavoritoEncontrado.IdUsuario = produtoFavoritoDTO.IdUsuario;
            }

            await _produtoFavoritoService.AtualizarAsync(id, produtoFavoritoEncontrado);

            return Ok(new
            {
                mensagem = $"Produto favorito com o id {id} foi atualizada com sucesso"
            });
        }

        [HttpDelete("{id}", Name = "DeleteProdutoFavorito")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<ProdutoFavoritoDTO>> DeleteAsync(Guid id)
        {
            var produtoFavoritoDto = await _produtoFavoritoService.GetByIdAsync(id);

            if (produtoFavoritoDto == null)
            {
                return NotFound("Produto Favorito não encontrado");
            }
            await _produtoFavoritoService.DeleteAsync(id);

            return Ok(new
            {
                message = "Produto favorito removido com sucesso"
            });
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
