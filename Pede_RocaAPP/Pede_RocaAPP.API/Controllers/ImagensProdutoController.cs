using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/imagens-produtos")]
    public class ImagensProdutosController : ControllerBase
    {
        private readonly IImagensProdutosService _service;

        public ImagensProdutosController(IImagensProdutosService imagensProdutos)
        {
            _service = imagensProdutos;
        }

        [HttpPost(Name = "AdicionarImagemDeProduto")]
        public async Task<ActionResult> Post([FromBody] ImagensProdutosCreateDTO imagensProdutos)
        {
            if (imagensProdutos == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var id_imagem_produto = await _service.AdicionarAsync(imagensProdutos);

            return CreatedAtRoute("GetImagemDeProduto", new { id = id_imagem_produto }, new
            {
                id = id_imagem_produto,
                message = "Imagem de produto criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarImagemDeProduto")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ImagensProdutosCreateDTO imagensProdutos)
        {
            if (imagensProdutos == null) return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            var imagem_produto_encontrado = await _service.GetByIdUpdateAsync(id);

            if(imagem_produto_encontrado == null) return NotFound($"Imagem de produto com o ID {id} não foi encontrado. Verifique o ID e tente novamente!");
            if(imagem_produto_encontrado.Url != imagensProdutos.Url) imagem_produto_encontrado.Url = imagensProdutos.Url;

            await _service.AtualizarAsync(id, imagem_produto_encontrado);
            return Ok(new { mensagem = $"Imagem de produto com o id {id} foi atualizada com sucesso" });
        }

        [HttpGet("{id}", Name = "GetImagemDeProduto")]
        public async Task<ActionResult<ImagensProdutosDTO>> Get(Guid id)
        {
            var imagem_produto_encontrado = await _service.GetByIdAsync(id);
            if (imagem_produto_encontrado == null) return NotFound("Imagem de produto não encontrada");

            return Ok(imagem_produto_encontrado);
        }

        [HttpGet(Name = "GetAllImagensDeProdutos")]
        public async Task<ActionResult<IEnumerable<ImagensProdutosDTO>>> GetAll()
        {
            var imagens_produtos_encontradas = await _service.GetAllAsync();
            if (imagens_produtos_encontradas == null || !imagens_produtos_encontradas.Any()) return Ok(new List<ImagensProdutosDTO>());
            
            return Ok(imagens_produtos_encontradas);
        }

        [HttpDelete("{id}", Name = "DeleteImagemDeProduto")]
        public async Task<ActionResult<ImagensProdutosDTO>> DeleteAsync(Guid id)
        {
            var imagem_produto_encontrado = await _service.GetByIdAsync(id);
            if (imagem_produto_encontrado == null) return NotFound("Imagem de produto não encontrada");

            await _service.DeletarAsync(id);
            return Ok(new { message = "Imagem de produto removida com sucesso" });
        }
    }
}
