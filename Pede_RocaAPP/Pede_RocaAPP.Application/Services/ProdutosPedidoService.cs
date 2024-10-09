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

        public async Task AdicionarAsync(ProdutosPedidoDTO produtosPedidoDTO)
        {
            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AdicionarAsync(produtosPedido);
        }

        public async Task AtualizarAsync(Guid id, ProdutosPedidoDTO produtosPedidoDTO)
        {
            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AtualizarAsync(id, produtosPedido);
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

        public async Task<IEnumerable<ProdutosPedidoDTO>> GetAllAsync()
        {
            var produtosFavoritos = await _produtosPedidoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutosPedidoDTO>>(produtosFavoritos);
        }
    }
}
