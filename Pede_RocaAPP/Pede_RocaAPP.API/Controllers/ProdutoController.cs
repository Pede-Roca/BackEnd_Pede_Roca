using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

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
        public async Task<ActionResult> Post([FromBody] ProdutoCreateDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var produtoId = await _produtoService.AdicionarAsync(produtoDTO);

            return CreatedAtRoute("GetProduto", new { id = produtoId }, new
            {
                id = produtoId,
                message = "Produto criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarProduto")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoCreateDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var produtoEncontrado = await _produtoService.GetByIdUpdateAsync(id);

            if (produtoEncontrado == null)
            {
                return NotFound($"Produto com ID {id} não encontrada. Verifique o ID e tente novamente!");
            }

            if(produtoEncontrado.Nome != produtoDTO.Nome)
            {
                produtoEncontrado.Nome = produtoDTO.Nome;
            }

            if (produtoEncontrado.Descricao != produtoDTO.Descricao)
            {
                produtoEncontrado.Descricao = produtoDTO.Descricao;
            }

            if(produtoEncontrado.Preco != produtoDTO.Preco)
            {
                produtoEncontrado.Preco = produtoDTO.Preco;
            }

            if (produtoEncontrado.Status != produtoDTO.Status)
            {
                produtoEncontrado.Status = produtoDTO.Status;
            }

            if (produtoEncontrado.Estoque != produtoDTO.Estoque)
            {
                produtoEncontrado.Estoque = produtoDTO.Estoque;
            }

            if (produtoEncontrado.FatorPromocao != produtoDTO.FatorPromocao)
            {
                produtoEncontrado.FatorPromocao = produtoDTO.FatorPromocao;
            }

            if (produtoEncontrado.UidFoto != produtoDTO.UidFoto)
            {
                produtoEncontrado.UidFoto = produtoDTO.UidFoto;
            }

            if (produtoEncontrado.IdCategoria != produtoDTO.IdCategoria)
            {
                produtoEncontrado.IdCategoria = produtoDTO.IdCategoria;
            }

            if (produtoEncontrado.IdUnidade != produtoDTO.IdUnidade)
            {
                produtoEncontrado.IdUnidade = produtoDTO.IdUnidade;
            }


            await _produtoService.AtualizarAsync(id, produtoEncontrado);

            return Ok(new
            {
                mensagem = $"Produto com o id {id} foi atualizada com sucesso"
            });
        }

        [HttpDelete("{id}", Name = "DeleteProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<ProdutoDTO>> DeleteAsync(Guid id)
        {
            var produtoDto = await _produtoService.GetByIdAsync(id);
            
            if (produtoDto == null)
            {
                return NotFound("Produto não encontrado");
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
