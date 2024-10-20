using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ProdutosPedidoService : IProdutosPedidoService
    {
        private readonly IProdutosPedidoRepository _produtosPedidoRepository;

        private readonly IMapper _mapper;

        public ProdutosPedidoService(IProdutosPedidoRepository produtosPedidoRepository, IMapper mapper)
        {
            _produtosPedidoRepository = produtosPedidoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AdicionarAsync(produtosPedido);
            return produtosPedido.Id;
        }

        public async Task AtualizarAsync(Guid id, ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AtualizarAsync(id, produtosPedido);
        }

        public async Task AtualizarEstoqueProdutosAsync(Guid id, int quantidade, bool adicionar)
        {
            var produtoPedidoExistente = await _produtosPedidoRepository.GetByIdAsync(id);
            if (produtoPedidoExistente == null) throw new Exception("Produto Pedido não encontrado");

            if (adicionar)
            {
                produtoPedidoExistente.QuantidadeProduto += quantidade;
            }
            else
            {
                produtoPedidoExistente.QuantidadeProduto -= quantidade;
            }

            await _produtosPedidoRepository.AtualizarAsync(id, produtoPedidoExistente);
        }

        public async Task DeleteAsync(Guid id)
        {
            var produtosPedido = await _produtosPedidoRepository.GetByIdAsync(id);
            await _produtosPedidoRepository.DeleteAsync(produtosPedido);
        }

        public async Task<ProdutosPedidoDTO> GetByIdAsync(Guid id)
        {
            var produtosPedidos = await _produtosPedidoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutosPedidoDTO>(produtosPedidos);
        }

        public async Task<ProdutosPedidoCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var produtosPedido = await _produtosPedidoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<ProdutosPedidoCreateDTO>(produtosPedido);
        }

        public async Task<IEnumerable<ProdutosPedidoDTO>> GetAllAsync()
        {
            var produtosFavoritos = await _produtosPedidoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutosPedidoDTO>>(produtosFavoritos);
        }
    }
}
