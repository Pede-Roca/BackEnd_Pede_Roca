using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/produto-pedido")]
    public class ProdutosPedidoController : ControllerBase
    {
        private readonly IProdutosPedidoService _produtosPedidoService;
        private readonly IProdutoService _produtoService;

        public ProdutosPedidoController(IProdutosPedidoService produtosPedidoService, IProdutoService produtoService)
        {
            _produtosPedidoService = produtosPedidoService;
            _produtoService = produtoService;
        }

        [HttpPost(Name = "AdicionarProdutosPedido")]
        public async Task<ActionResult> Post([FromBody] ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            if (produtosPedidoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");

            var produto = await _produtoService.GetByIdAsync(produtosPedidoDTO.IdProduto);

            if (produto == null) return NotFound("Produto não encontrado");
            if (produtosPedidoDTO.QuantidadeProduto <= 0) return BadRequest("Quantidade de produto inválida, deve ser maior que 0.");
            if (produtosPedidoDTO.QuantidadeProduto > produto.Estoque) return BadRequest("Quantidade de produto maior que o estoque disponível");
            
            var produtosPedidoId = await _produtosPedidoService.AdicionarAsync(produtosPedidoDTO);
            await _produtoService.AtualizarEstoqueProdutosAsync(produtosPedidoDTO.IdProduto, produtosPedidoDTO.QuantidadeProduto, false);

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

            if (produtosPedidoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            if (produtosPedidoExistente == null) return NotFound($"Produto pedido com ID {id} não encontrada. Verifique o ID e tente novamente!");

            if (produtosPedidoExistente.IdProduto != produtosPedidoDTO.IdProduto) produtosPedidoExistente.IdProduto = produtosPedidoDTO.IdProduto;
            if (produtosPedidoExistente.QuantidadeProduto != produtosPedidoDTO.QuantidadeProduto) produtosPedidoExistente.QuantidadeProduto = produtosPedidoDTO.QuantidadeProduto;
        
            await _produtosPedidoService.AtualizarAsync(id, produtosPedidoExistente);

            return Ok(new { mensagem = $"Produto pedido com o id {id} foi atualizada com sucesso" });
        }

        [HttpPut("atualizar-quantidade-produto/{id}", Name = "AtualizarQuantidadeProduto")]
        public async Task<ActionResult> PutQuantidadeProduto(Guid id, [FromBody] ProdutoPedidoAtualizarEstoqueRequest atualizarEstoqueRequest)
        {
            var produtosPedidoExistente = await _produtosPedidoService.GetByIdUpdateAsync(id);
            if (produtosPedidoExistente == null) return NotFound($"Produto pedido com ID {id} não encontrada. Verifique o ID e tente novamente!");

            var produto = await _produtoService.GetByIdAsync(produtosPedidoExistente.IdProduto);
            if (produto == null) return NotFound("Produto não encontrado");

            if (atualizarEstoqueRequest.Adicionar)
            {
                if (atualizarEstoqueRequest.Quantidade > produto.Estoque) return BadRequest("Quantidade de produto maior que o estoque disponível");
                await _produtosPedidoService.AtualizarEstoqueProdutosAsync(id, atualizarEstoqueRequest.Quantidade, true);
                await _produtoService.AtualizarEstoqueProdutosAsync(produtosPedidoExistente.IdProduto, atualizarEstoqueRequest.Quantidade, true);
            }
            else
            {
                await _produtosPedidoService.AtualizarEstoqueProdutosAsync(id, atualizarEstoqueRequest.Quantidade, false);
                await _produtoService.AtualizarEstoqueProdutosAsync(produtosPedidoExistente.IdProduto, atualizarEstoqueRequest.Quantidade, false);
            }

            return Ok(new { mensagem = $"Produto pedido com o id {id} foi atualizada com sucesso" });
        }

        [HttpGet("{id}", Name = "GetProdutosPedido")]
        public async Task<ActionResult<ProdutosPedidoDTO>> Get(Guid id)
        {
            var produtosPedidoDTO = await _produtosPedidoService.GetByIdAsync(id);
            if (produtosPedidoDTO == null) return NotFound("Produtos Pedido não encontrado");

            return Ok(produtosPedidoDTO);
        }

        [HttpGet(Name = "GetAllProdutosPedidos")]
        public async Task<ActionResult<IEnumerable<ProdutosPedidoDTO>>> GetAll()
        {
            var produtosPedidos = await _produtosPedidoService.GetAllAsync();
            if (produtosPedidos == null) return Ok(new List<ProdutosPedidoDTO>());

            return Ok(produtosPedidos);
        }

        [HttpDelete("{id}", Name = "DeleteProdutosPedido")]
        public async Task<ActionResult<ProdutosPedidoDTO>> DeleteAsync(Guid id)
        {
            var produtosPedidoDTO = await _produtosPedidoService.GetByIdAsync(id);
            if (produtosPedidoDTO == null) return NotFound("Produtos Pedido não encontrado");

            await _produtosPedidoService.DeleteAsync(id);

            return Ok(new { message = "Produto Pedidos removido com sucesso" });
        }
    }
}
