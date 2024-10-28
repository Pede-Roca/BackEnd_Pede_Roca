using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ComprasFinalizadasService : IComprasFinalizadasService
    {
        private readonly IMapper _mapper;
        private readonly IComprasFinalizadasRepository _repository;

        public ComprasFinalizadasService(IComprasFinalizadasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(ComprasFinalizadasCreateDTO finalizadasDTO)
        {
            finalizadasDTO.Data = DateTime.Now; // Usa a data e hora atual
            finalizadasDTO.Status = true;
            finalizadasDTO.DataEntrega = null;

            var entity = _mapper.Map<ComprasFinalizadas>(finalizadasDTO);
            await _repository.AdicionarAsync(entity);
            return entity.Id;
        }

        public async Task AtualizarAsync(Guid id, ComprasFinalizadasUpdateDTO finalizadasDTO)
        {
            var entity = _mapper.Map<ComprasFinalizadas>(finalizadasDTO);
            await _repository.AtualizarAsync(id, entity);
        }

        public async Task<IEnumerable<ComprasFinalizadasDTO>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ComprasFinalizadasDTO>>(entity);
        }

        public async Task<ComprasFinalizadasDTO> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ComprasFinalizadasDTO>(entity);
        }

        public async Task<ComprasFinalizadasUpdateDTO> GetByIdUpdateAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ComprasFinalizadasUpdateDTO>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}