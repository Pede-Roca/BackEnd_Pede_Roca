using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosPedidoController : ControllerBase
    {
        private readonly IProdutosPedidoService _produtosPedidoService;

        public ProdutosPedidoController(IProdutosPedidoService produtosPedidoService)
        {
            _produtosPedidoService = produtosPedidoService;
        }

        [HttpPost(Name = "AdicionarProdutosPedido")]
        public async Task<ActionResult> Post([FromBody] ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            if (produtosPedidoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var produtosPedidoId = await _produtosPedidoService.AdicionarAsync(produtosPedidoDTO);

            return CreatedAtRoute("GetProdutosPedido", new { id = produtosPedidoId }, new
            {
                id = produtosPedidoId,
                message = "Produtos pedido criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarProdutosPedido")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            var produtosPedidoExistente = await _produtosPedidoService.GetByIdUpdateAsync(id);

            if (produtosPedidoDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            // Busca o produto pedido atual do banco de dados sem rastreamento
            if (produtosPedidoExistente == null)
            {
                return NotFound($"Produto pedido com ID {id} não encontrada. Verifique o ID e tente novamente!");
            }

            if(produtosPedidoExistente.IdProduto != produtosPedidoDTO.IdProduto)
            {
                produtosPedidoExistente.IdProduto = produtosPedidoDTO.IdProduto;
            }

            if (produtosPedidoExistente.QuantidadeProduto != produtosPedidoDTO.QuantidadeProduto)
            {
                produtosPedidoExistente.QuantidadeProduto = produtosPedidoDTO.QuantidadeProduto;
            }

            await _produtosPedidoService.AtualizarAsync(id, produtosPedidoExistente);

            return Ok(new
            {
                mensagem = $"Produto pedido com o id {id} foi atualizada com sucesso"
            });

        }

        [HttpDelete("{id}", Name = "DeleteProdutosPedido")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<ProdutosPedidoDTO>> DeleteAsync(Guid id)
        {
            var produtosPedidoDTO = await _produtosPedidoService.GetByIdAsync(id);
            if (produtosPedidoDTO == null)
            {
                return NotFound("Produtos Pedido não encontrado");
            }
            await _produtosPedidoService.DeleteAsync(id);

            return Ok(new
            {
                message = "Produto Pedidos removido com sucesso"
            });
        }

        [HttpGet("{id}", Name = "GetProdutosPedido")]
        public async Task<ActionResult<ProdutosPedidoDTO>> Get(Guid id)
        {
            var produtosPedidoDTO = await _produtosPedidoService.GetByIdAsync(id);
            if (produtosPedidoDTO == null)
            {
                return NotFound("Produtos Pedido não encontrado");
            }
            return Ok(produtosPedidoDTO);
        }

        [HttpGet(Name = "GetAllProdutosPedidos")]
        public async Task<ActionResult<IEnumerable<ProdutosPedidoDTO>>> GetAll()
        {
            var produtosPedidos = await _produtosPedidoService.GetAllAsync();
            if (produtosPedidos == null)
            {
                return NotFound("Nenhum Produto Pedido encontrado");
            }
            return Ok(produtosPedidos);
        }
    }
}
