using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoCompraService)
        {
            _carrinhoCompraService = carrinhoCompraService;
        }

        [HttpPost(Name = "AdicionarCarrinhoCompra")]
        public async Task<ActionResult> Post([FromBody] CarrinhoCompraCreateDTO carrinhoCompraDTO)
        {
            if (carrinhoCompraDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }
            var carrinhoCompraId = await _carrinhoCompraService.AdicionarAsync(carrinhoCompraDTO);

            return CreatedAtRoute("GetCarrinhoCompra", new { id = carrinhoCompraId }, new
            {
                id = carrinhoCompraId,
                message = "Carrinho de compra criado com sucesso!"
            });
        }

        [HttpPut("{id}", Name = "AtualizarCarrinhoCompra")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CarrinhoComprUpdateDTO carrinhoCompraDTO)
        {
            if (carrinhoCompraDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var carrinhoCompraEncontrado = await _carrinhoCompraService.GetByIdUpdateAsync(id);

            if (carrinhoCompraEncontrado == null)
            {
                return NotFound($"Carrinho de compra com ID {id} não encontrado. Verifique o ID e tente novamente!");
            }

            if(!string.IsNullOrEmpty(carrinhoCompraDTO.Status))
            {
                carrinhoCompraEncontrado.Status = carrinhoCompraDTO.Status;
            }

            await _carrinhoCompraService.AtualizarAsync(id, carrinhoCompraEncontrado);

            return Ok(new
            {
                mensagem = $"Carrinho de compra com o {id} foi atualizado com sucesso"
            });
        }

        [HttpDelete("{id}", Name = "DeleteCarrinhoCompra")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<CarrinhoCompraDTO>> DeleteAsync(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdAsync(id);
            if (carrinhoCompraDto == null)
            {
                return NotFound("Carrinho de compra não encontrado");
            }
            await _carrinhoCompraService.DeleteAsync(id);

            return Ok(new
            {
                message = "Carrinho de compra foi removido com sucesso"
            });
        }

        [HttpGet("{id}", Name = "GetCarrinhoCompra")]
        public async Task<ActionResult<CarrinhoCompraDTO>> Get(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdAsync(id);
            if (carrinhoCompraDto == null)
            {
                return NotFound("Carrinho de compra não encontrado");
            }

            return Ok(carrinhoCompraDto);
        }

        [HttpGet(Name = "GetAllCarrinhoCompra")]
        public async Task<ActionResult<IEnumerable<CarrinhoCompraDTO>>> Get()
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetAllAsync();
            if (carrinhoCompraDto == null)
            {
                return NotFound("Carrinho de compra não encontrado");
            }

            return Ok(carrinhoCompraDto);
        }
    }
}