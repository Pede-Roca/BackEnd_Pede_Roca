using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/produto")]
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
            if (produtoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
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
            if (produtoDTO == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var produtoEncontrado = await _produtoService.GetByIdUpdateAsync(id);

            if (produtoEncontrado == null) return NotFound($"Produto com ID {id} não encontrada. Verifique o ID e tente novamente!");
            if (produtoEncontrado.Nome != produtoDTO.Nome) produtoEncontrado.Nome = produtoDTO.Nome;
            if (produtoEncontrado.Descricao != produtoDTO.Descricao) produtoEncontrado.Descricao = produtoDTO.Descricao;
            if (produtoEncontrado.Preco != produtoDTO.Preco) produtoEncontrado.Preco = produtoDTO.Preco;
            if (produtoEncontrado.Status != produtoDTO.Status) produtoEncontrado.Status = produtoDTO.Status;
            if (produtoEncontrado.Estoque != produtoDTO.Estoque) produtoEncontrado.Estoque = produtoDTO.Estoque;
            if (produtoEncontrado.FatorPromocao != produtoDTO.FatorPromocao) produtoEncontrado.FatorPromocao = produtoDTO.FatorPromocao;
            if (produtoEncontrado.UidFoto != produtoDTO.UidFoto) produtoEncontrado.UidFoto = produtoDTO.UidFoto;
            if (produtoEncontrado.IdCategoria != produtoDTO.IdCategoria) produtoEncontrado.IdCategoria = produtoDTO.IdCategoria;
            if (produtoEncontrado.IdUnidade != produtoDTO.IdUnidade) produtoEncontrado.IdUnidade = produtoDTO.IdUnidade;

            await _produtoService.AtualizarAsync(id, produtoEncontrado);

            return Ok(new { mensagem = $"Produto com o id {id} foi atualizada com sucesso" });
        }

        [HttpPut("alterar-foto-produto/{id}", Name = "AtualizarFotoProduto")]
        public async Task<ActionResult> PutFotoProduto(Guid id, [FromBody] AtualizarFotoProdutoRequest atualizarFotoPerfil)
        {
            var produtoExistente = await _produtoService.GetByIdAsync(id);
            if (produtoExistente == null) return NotFound("Usuário não encontrado");

            await _produtoService.AtualizarFotoProdutoAsync(id, atualizarFotoPerfil.UidFotoProduto);
            return Ok(new { message = "Foto de produto atualizada com sucesso" });
        }

        [HttpPut("alterar-status-produto/{id}", Name = "AtualizarStatusProduto")]
        public async Task<ActionResult> PutStatusProduto(Guid id, [FromBody] AtualizarStatusProdutoResponse atualizarStatusProdutoResponse)
        {
            var produtoExistente = await _produtoService.GetByIdAsync(id);
            if (produtoExistente == null) return NotFound("Produto não encontrado");

            await _produtoService.AtualizarStatusProdutoAsync(id, atualizarStatusProdutoResponse.Status);
            return Ok(new { message = "Status do produto atualizado com sucesso" });
        }

        [HttpPut("alterar-estoque-produto/{id}", Name = "AtualizarEstoqueProduto")]
        public async Task<ActionResult> PutEstoqueProduto(Guid id, [FromBody] AtualizarEstoqueProdutoResponse atualizarEstoqueProdutoResponse)
        {
            var produtoExistente = await _produtoService.GetByIdAsync(id);
            if (produtoExistente == null) return NotFound("Produto não encontrado");

            await _produtoService.AtualizarEstoqueProdutosAsync(id, atualizarEstoqueProdutoResponse.Quantidade, atualizarEstoqueProdutoResponse.Adicionar);
            return Ok(new { message = "Estoque do produto atualizado com sucesso" });
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound("Produto não encontrado");

            return Ok(produto);
        }

        [HttpGet(Name = "GetAllProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            if (produtos == null) return Ok(new List<ProdutoDTO>());

            return Ok(produtos);
        }

        [HttpGet("sem-estoque", Name = "GetProdutoSemEstoque")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosSemEstoque()
        {
            var produtos = await _produtoService.GetProdutosSemEstoqueAsync();
            if (produtos == null || !produtos.Any()) return Ok(new List<ProdutoDTO>());

            return Ok(produtos);
        }

        [HttpDelete("{id}", Name = "DeleteProduto")]
        public async Task<ActionResult<ProdutoDTO>> DeleteAsync(Guid id)
        {
            var produtoDto = await _produtoService.GetByIdAsync(id);
            if (produtoDto == null) return NotFound("Produto não encontrado");

            await _produtoService.DeleteAsync(id);
            return Ok(produtoDto);
        }
    }
}
