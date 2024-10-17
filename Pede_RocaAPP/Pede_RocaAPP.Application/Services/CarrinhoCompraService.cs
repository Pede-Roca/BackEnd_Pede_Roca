using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly IMapper _mapper;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        private readonly IProdutosPedidoRepository _produtosPedidoRepository;

        public CarrinhoCompraService(ICarrinhoCompraRepository carrinhoCompraRepository, IMapper mapper, IProdutosPedidoRepository produtosPedidoRepository)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _mapper = mapper;
            _produtosPedidoRepository = produtosPedidoRepository;
        }

        public async Task<Guid> AdicionarAsync(CarrinhoCompraCreateDTO carrinhoCompraDTO)
        {
            var carrinhoCompraEntity = _mapper.Map<CarrinhoCompra>(carrinhoCompraDTO);
            await _carrinhoCompraRepository.AdicionarAsync(carrinhoCompraEntity);
            return carrinhoCompraEntity.Id;
        }

        public async Task AdicionarProdutoNoCarrinho(CarrinhoComprasProdutosPedidoDTO carrinhoComprasProdutosPedido)
        {
            var carrinhoComprasProdutosPedidoEntity = _mapper.Map<CarrinhoComprasProdutosPedido>(carrinhoComprasProdutosPedido);
            await _carrinhoCompraRepository.AdicionarProdutoNoCarrinho(carrinhoComprasProdutosPedidoEntity);
        }

        public async Task AtualizarAsync(Guid id, CarrinhoCompraDTO carrinhoCompraDTO)
        {
            var carrinhoCompraEntity = _mapper.Map<CarrinhoCompra>(carrinhoCompraDTO);
            await _carrinhoCompraRepository.AtualizarAsync(id, carrinhoCompraEntity);
        }

        public async Task<IEnumerable<CarrinhoCompraDTO>> GetAllAsync()
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarrinhoCompraDTO>>(carrinhoCompraEntity);
        }

        public async Task<IEnumerable<ItensCarrinhoCompraDTO>> GetProdutosNoCarrinhoCompra(Guid idUsuario)
        {
            var itensCarrinhoCompraEntity = await _carrinhoCompraRepository.GetProdutosNoCarrinhoCompra(idUsuario);
            return _mapper.Map<IEnumerable<ItensCarrinhoCompraDTO>>(itensCarrinhoCompraEntity);
        }

        public async Task<CarrinhoCompraDTO> GetByIdAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdAsync(id);
            return _mapper.Map<CarrinhoCompraDTO>(carrinhoCompraEntity);
        }

        public async Task<CarrinhoCompraDTO> GetByIdUpdateAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<CarrinhoCompraDTO>(carrinhoCompraEntity);
        }

        public async Task<CarrinhoCompraDTO> GetByIdUsuarioAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdUsuarioAsync(id);
            return _mapper.Map<CarrinhoCompraDTO>(carrinhoCompraEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdAsync(id);
            await _carrinhoCompraRepository.DeleteAsync(carrinhoCompraEntity);
        }
    }
}