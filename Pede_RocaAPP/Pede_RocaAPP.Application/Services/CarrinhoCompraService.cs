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

        public CarrinhoCompraService(ICarrinhoCompraRepository carrinhoCompraRepository, IMapper mapper)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(CarrinhoCompraDTO carrinhoCompraDTO)
        {
            var carrinhoCompraEntity = _mapper.Map<CarrinhoCompra>(carrinhoCompraDTO);
            await _carrinhoCompraRepository.AdicionarAsync(carrinhoCompraEntity);
        }

        public async Task AtualizarAsync(Guid id, CarrinhoCompraDTO carrinhoCompraDTO)
        {
            var carrinhoCompraEntity = _mapper.Map<CarrinhoCompra>(carrinhoCompraDTO);
            await _carrinhoCompraRepository.AtualizarAsync(id, carrinhoCompraEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdAsync(id);
            await _carrinhoCompraRepository.DeleteAsync(carrinhoCompraEntity);
        }

        public async Task<CarrinhoCompraDTO> GetByIdAsync(Guid id)
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetByIdAsync(id);
            return _mapper.Map<CarrinhoCompraDTO>(carrinhoCompraEntity);
        }

        public async Task<IEnumerable<CarrinhoCompraDTO>> GetAllAsync()
        {
            var carrinhoCompraEntity = await _carrinhoCompraRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarrinhoCompraDTO>>(carrinhoCompraEntity);
        }
    }
}