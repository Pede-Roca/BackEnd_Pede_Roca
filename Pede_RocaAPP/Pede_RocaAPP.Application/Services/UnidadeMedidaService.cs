using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class UnidadeMedidaService : IUnidadeMedidaService
    {
        private readonly IMapper _mapper;
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;

        public UnidadeMedidaService(IUnidadeMedidaRepository unidadeMedidaRepository, IMapper mapper)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(UnidadeMedidaDTO unidadeMedidaDTO)
        {
            var unidadeMedidaEntity = _mapper.Map<UnidadeMedida>(unidadeMedidaDTO);
            await _unidadeMedidaRepository.AdicionarAsync(unidadeMedidaEntity);
        }

        public async Task AtualizarAsync(Guid id, UnidadeMedidaDTO unidadeMedidaDTO)
        {
            var unidadeMedidaEntity = _mapper.Map<UnidadeMedida>(unidadeMedidaDTO);
            await _unidadeMedidaRepository.AtualizarAsync(id, unidadeMedidaEntity);
        }

        public async Task DeletarAsync(Guid id)
        {
            var unidadeMedidaEntity = await _unidadeMedidaRepository.GetByIdAsync(id);
            await _unidadeMedidaRepository.DeleteAsync(unidadeMedidaEntity);
        }

        public async Task<UnidadeMedidaDTO> GetByIdAsync(Guid id)
        {
            var unidadeMedidaEntity = await _unidadeMedidaRepository.GetByIdAsync(id);
            return _mapper.Map<UnidadeMedidaDTO>(unidadeMedidaEntity);
        }

        public async Task<IEnumerable<UnidadeMedidaDTO>> GetAllAsync()
        {
            var unidadeMedidaEntity = await _unidadeMedidaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UnidadeMedidaDTO>>(unidadeMedidaEntity);
        }
    }
}
