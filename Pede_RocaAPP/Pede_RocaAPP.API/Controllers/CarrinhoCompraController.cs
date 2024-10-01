using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoCompraService)
        {
            _carrinhoCompraService = carrinhoCompraService;
        }

        [HttpPost(Name = "AdicionarCarrinhoCompra")]
        public async Task<ActionResult> Post([FromBody] CarrinhoCompraDTO carrinhoCompraDTO)
        {
            if (carrinhoCompraDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            await _carrinhoCompraService.AdicionarAsync(carrinhoCompraDTO);

            return CreatedAtRoute("GetCarrinhoCompra", new { id = carrinhoCompraDTO.Id }, carrinhoCompraDTO);
        }

        [HttpPut("{id}", Name = "AtualizarCarrinhoCompra")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CarrinhoCompraDTO carrinhoCompraDTO)
        {
            if (id != carrinhoCompraDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (carrinhoCompraDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _carrinhoCompraService.AtualizarAsync(id, carrinhoCompraDTO);
            return Ok(carrinhoCompraDTO);
        }

        [HttpDelete("{id}", Name = "DeleteCarrinhoCompra")]
        public async Task<ActionResult<CarrinhoCompraDTO>> DeleteAsync(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdAsync(id);
            if (carrinhoCompraDto == null)
            {
                return NotFound("Carrinho de compra não encontrado");
            }
            await _carrinhoCompraService.DeleteAsync(id);

            return Ok(carrinhoCompraDto);
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