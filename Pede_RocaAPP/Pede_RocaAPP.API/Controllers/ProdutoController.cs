using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost(Name = "AdicionarProduto")]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _produtoService.AdicionarAsync(produtoDTO);

            return CreatedAtRoute("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
        }

        [HttpPut("{id}", Name = "AtualizarProduto")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (produtoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _produtoService.AtualizarAsync(id, produtoDTO);
            return Ok(produtoDTO);
        }


        [HttpDelete("{id}", Name = "DeleteProduto")]
        public async Task<ActionResult<ProdutoDTO>> DeleteAsync(Guid id)
        {
            var produtoDto = await _produtoService.GetByIdAsync(id);
            if (produtoDto == null)
            {
                return NotFound("Endereço não encontrado");
            }
            await _produtoService.DeleteAsync(id);
            return Ok(produtoDto);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(Guid id)
        {
            var produtoDto = await _produtoService.GetByIdAsync(id);
            if(produtoDto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produtoDto);
        }

        [HttpGet(Name = "GetAllProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado");
            }
            return Ok(produtos);
        }
    }
}
