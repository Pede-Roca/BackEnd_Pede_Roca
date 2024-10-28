using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;


namespace Pede_RocaAPP.API.Controllers
{
    [ApiController]
    [Route("api/carrinho-compra")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoCompraService;
        private readonly IProdutoService _produtoService;
        private readonly IProdutosPedidoService _produtosPedidoService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoCompraService, IProdutoService produtoService, IProdutosPedidoService produtosPedidoService)
        {
            _carrinhoCompraService = carrinhoCompraService;
            _produtoService = produtoService;
            _produtosPedidoService = produtosPedidoService;
        }

        [HttpPost(Name = "AdicionarCarrinhoCompra")]
        public async Task<ActionResult> Post([FromBody] CarrinhoCompraCreateDTO carrinhoCompraDTO)
        {
            if (!IsValid(carrinhoCompraDTO, out var errorMessage)) return BadRequest(errorMessage);

            var carrinhoCompraEncontrado = await _carrinhoCompraService.GetByIdUsuarioAsync(carrinhoCompraDTO.IdUsuario);
            if (carrinhoCompraEncontrado != null && carrinhoCompraEncontrado.Status == true) return BadRequest("Já existe um carrinho de compra ativo para o usuário informado.");

            carrinhoCompraDTO.Status = true;
            carrinhoCompraDTO.Data = DateTime.Now;
            var carrinhoCompraId = await _carrinhoCompraService.AdicionarAsync(carrinhoCompraDTO);
            return CreatedAtRoute("GetCarrinhoCompra", new { id = carrinhoCompraId }, new
            {
                id = carrinhoCompraId,
                message = "Carrinho de compra criado com sucesso!"
            });
        }

        [HttpPost("adicionar-no-carrinho", Name = "AdicionarNoCarrinho")]
        public async Task<ActionResult> AdicionarNoCarrinho([FromBody] CarrinhoComprasProdutosPedidoDTO carrinhoComprasProdutosPedidoDTO)
        {
            if (!IsValid(carrinhoComprasProdutosPedidoDTO, out var errorMessage)) return BadRequest(errorMessage);

            try
            {
                await _carrinhoCompraService.AdicionarProdutoNoCarrinho(carrinhoComprasProdutosPedidoDTO);
                return Ok(new { message = "Produto adicionado ao carrinho de compras com sucesso!" });
            }
            catch (Exception ex)
            {
                return HandleException(ex, "Erro ao adicionar produto ao carrinho.");
            }
        }

        [HttpGet(Name = "GetAllCarrinhoCompra")]
        public async Task<ActionResult<IEnumerable<CarrinhoCompraDTO>>> Get()
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetAllAsync();
            return carrinhoCompraDto == null ? Ok(new List<CarrinhoCompraDTO>()) : Ok(carrinhoCompraDto);
        }

        [HttpGet("produtos-mais-vendidos", Name = "Get10ProdutosMaisVendidos")]
        public async Task<ActionResult<IEnumerable<Top10ProdutosMaisVendidos>>> Get10ProdutosMaisVendidos()
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetTop10ProdutosMaisVendidos();
            return carrinhoCompraDto == null ? NotFound("Não foi possivel mapear os 10 produtos mais vendidos.") : Ok(carrinhoCompraDto);
        }

        [HttpGet("itens-carrinho-por-usuario", Name = "GetItensNoCarrinho")]
        public async Task<ActionResult<IEnumerable<ItensCarrinhoCompraDTO>>> GetItensNoCarrinho([FromQuery] Guid idUsuario, [FromQuery] Guid idCarrinhoCompra)
        {
            var itensCarrinhoCompra = await _carrinhoCompraService.GetProdutosNoCarrinhoCompra(idUsuario, idCarrinhoCompra);
            return itensCarrinhoCompra == null ? NotFound("Nenhum carrinho de compra encontrado.") : Ok(itensCarrinhoCompra);
        }

        [HttpGet("buscar-por-id/{id}", Name = "GetCarrinhoCompra")]
        public async Task<ActionResult<CarrinhoCompraDTO>> Get(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdAsync(id);
            return carrinhoCompraDto == null ? NotFound("Carrinho de compra não encontrado.") : Ok(carrinhoCompraDto);
        }

        [HttpGet("buscar-por-id-usuario/{id}", Name = "GetCarrinhoCompraPorIdUsuario")]
        public async Task<ActionResult<CarrinhoCompraDTO>> GetPorIdUsuario(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdUsuarioAsync(id);
            return carrinhoCompraDto == null ? NotFound("Carrinho de compra não encontrado.") : Ok(carrinhoCompraDto);
        }

        [HttpGet("buscar-historico-por-id-usuario/{id}", Name = "GetHistoricoCarrinhoCompraPorIdUsuario")]
        public async Task<ActionResult<IEnumerable<HistoricoCarrinhoCompraResponseDTO>>> GetHistoricoPorIdUsuario(Guid id)
        {
            // Recupera o histórico do carrinho do usuário
            var carrinhoCompraDtos = await _carrinhoCompraService.GetHistoricoByIdUsuarioAsync(id);

            if (carrinhoCompraDtos == null || !carrinhoCompraDtos.Any())
            {
                return NotFound("Usuário não tem um histórico de carrinho de compra.");
            }

            // Mapeia cada `CarrinhoCompra` para `HistoricoCarrinhoCompraResponse` e busca itens do carrinho
            var historicoCarrinhoResponse = new List<HistoricoCarrinhoCompraResponseDTO>();

            foreach (var carrinho in carrinhoCompraDtos)
            {
                // Recupera os itens do carrinho para o carrinho atual
                var itensCarrinhoCompra = await _carrinhoCompraService.GetProdutosNoCarrinhoCompra(carrinho.IdUsuario, carrinho.Id);

                // Adiciona o carrinho com seus itens à lista de resposta
                historicoCarrinhoResponse.Add(new HistoricoCarrinhoCompraResponseDTO
                {
                    IdCarrinhoCompra = carrinho.Id,
                    Data = carrinho.Data,
                    Status = carrinho.Status,
                    ItensCarrinhoCompra = itensCarrinhoCompra
                });
            }

            return Ok(historicoCarrinhoResponse);
        }


        [HttpPut("atualizar-status/{id}", Name = "AtualizarCarrinhoCompra")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CarrinhoCompraUpdateDTO carrinhoCompraDTO)
        {
            if (!IsValid(carrinhoCompraDTO, out var errorMessage)) return BadRequest(errorMessage);

            var carrinhoCompraEncontrado = await _carrinhoCompraService.GetByIdUpdateAsync(id);
            if (carrinhoCompraEncontrado == null) return NotFound($"Carrinho de compra com ID {id} não encontrado.");

            await _carrinhoCompraService.AtualizarAsync(id, carrinhoCompraEncontrado);
            return Ok(new { message = $"Carrinho de compra com ID {id} atualizado com sucesso." });
        }

        [HttpPost("remover-produto-carrinho", Name = "RemoverProdutoCarrinho")]
        public async Task<ActionResult> RemoverProdutoCarrinho([FromBody] CarrinhoComprasRemoverProdutosPedidoRequest carrinhoComprasRemover)
        {
            var carrinhoCompraExistente = await _carrinhoCompraService.GetByIdAsync(carrinhoComprasRemover.IdCarrinhoCompra);
            if (carrinhoCompraExistente == null)
                return NotFound("Carrinho de compra não encontrado.");

            var produtoPedidoExistente = await _produtosPedidoService.GetByIdAsync(carrinhoComprasRemover.IdProdutoPedido);
            if (produtoPedidoExistente == null)
                return NotFound("Produto Pedido não encontrado.");

            var produtoExistente = await _produtoService.GetByIdAsync(produtoPedidoExistente.IdProduto);
            if (produtoExistente == null)
                return NotFound("Produto não encontrado.");

            // Atualiza o estoque do produto
            await _produtoService.AtualizarEstoqueProdutosAsync(produtoPedidoExistente.IdProduto, produtoPedidoExistente.QuantidadeProduto, true);

            // Remove o produto do carrinho
            await _carrinhoCompraService.RemoverProdutoDoCarrinhoAsync(carrinhoComprasRemover.IdCarrinhoCompra, carrinhoComprasRemover.IdProdutoPedido);

            // Retorna o sucesso da operação
            return Ok(new { message = "Produto removido do carrinho com sucesso." });
        }

        [HttpPost("finalizar-compra/{id_carrinho}", Name = "FinalizarCompra")]
        public async Task<ActionResult> FinalizarCompra(Guid id_carrinho)
        {
            var carrinhoCompraExistenteDTO = await _carrinhoCompraService.GetByIdAsync(id_carrinho);

            if (carrinhoCompraExistenteDTO == null)
                return NotFound("Carrinho de compra não encontrado.");

            var carrinhoCompraExistente = new CarrinhoCompra
            {
                Id = carrinhoCompraExistenteDTO.Id,
                Status = carrinhoCompraExistenteDTO.Status,
                Data = carrinhoCompraExistenteDTO.Data,
                IdUsuario = carrinhoCompraExistenteDTO.IdUsuario,
            };

            FinalizarCompraResponse finalizarCompraResponse = await _carrinhoCompraService.FinalizarCompraDoCarrinhoAsync(id_carrinho, carrinhoCompraExistente);

            if (!finalizarCompraResponse.Sucesso)
            {
                return BadRequest(new
                {
                    message = finalizarCompraResponse.Message,
                    produtosSemEstoque = finalizarCompraResponse.ProdutosSemEstoque
                });
            }

            return Ok(new
            {
                message = finalizarCompraResponse.Message
            });

        }

        [HttpDelete("{id}", Name = "DeleteCarrinhoCompra")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var carrinhoCompraDto = await _carrinhoCompraService.GetByIdAsync(id);
            if (carrinhoCompraDto == null) return NotFound("Carrinho de compra não encontrado.");

            await _carrinhoCompraService.DeleteAsync(id);
            return Ok(new { message = "Carrinho de compra removido com sucesso." });
        }

        private bool IsValid<T>(T dto, out string errorMessage)
        {
            if (dto == null)
            {
                errorMessage = "Dados inválidos. Verifique o payload e tente novamente.";
                return false;
            }
            errorMessage = null;
            return true;
        }

        private ActionResult HandleException(Exception ex, string message)
        {
            Console.WriteLine($"Erro: ", ex);
            return StatusCode(500, message);
        }
    }
}
