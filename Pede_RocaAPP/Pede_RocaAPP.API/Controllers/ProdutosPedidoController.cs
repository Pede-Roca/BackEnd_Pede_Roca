using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosPedidoController : ControllerBase
    {
        private readonly IProdutosPedidoService _produtosPedidoService;

        public ProdutosPedidoController(IProdutosPedidoService produtosPedidoService)
        {
            _produtosPedidoService = produtosPedidoService;
        }

        [HttpPost(Name = "AdicionarProdutosPedido")]
        public async Task<ActionResult> Post([FromBody] ProdutosPedidoDTO produtosPedidoDTO)
        {
            if (produtosPedidoDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _produtosPedidoService.AdicionarAsync(produtosPedidoDTO);

            return CreatedAtRoute("GetProdutosPedido", new { id = produtosPedidoDTO.Id }, produtosPedidoDTO);
        }

        [HttpPut("{id}", Name = "AtualizarProdutosPedido")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutosPedidoDTO produtosPedidoDTO)
        {
            var produtosPedidoExistente = await _produtosPedidoService.GetByIdAsync(id);

            
            // Busca o produto pedido atual do banco de dados sem rastreamento
            if (produtosPedidoExistente == null)
            {
                return NotFound("Produto Pedido não encontrado");
            }

            if (id != produtosPedidoExistente.Id)
            {
                return BadRequest("Id não válido");
            }

            if (produtosPedidoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            produtosPedidoExistente.QuantidadeProduto = produtosPedidoDTO.QuantidadeProduto > 0 ? produtosPedidoDTO.QuantidadeProduto : produtosPedidoDTO.QuantidadeProduto;
            produtosPedidoExistente.IdProduto = produtosPedidoDTO.IdProduto != Guid.Empty ? produtosPedidoDTO.IdProduto : produtosPedidoExistente.IdProduto;

            await _produtosPedidoService.AtualizarAsync(id, produtosPedidoExistente);

            return Ok(produtosPedidoExistente);
            
        }




        [HttpDelete("{id}", Name = "DeleteProdutosPedido")]
        public async Task<ActionResult<ProdutosPedidoDTO>> DeleteAsync(Guid id)
        {
            var produtosPedidoDTO = await _produtosPedidoService.GetByIdAsync(id);
            if (produtosPedidoDTO == null)
            {
                return NotFound("Produtos Pedido não encontrado");
            }
            await _produtosPedidoService.DeleteAsync(id);

            return Ok(produtosPedidoDTO);
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
