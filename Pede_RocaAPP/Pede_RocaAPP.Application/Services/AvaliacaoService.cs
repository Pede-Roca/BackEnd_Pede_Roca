using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IMapper _mapper;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(AvaliacaoCreateDTO avaliacaoDTO)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoDTO);
            await _avaliacaoRepository.AdicionarAsync(avaliacao);

            return avaliacao.Id;
        }

        public async Task AtualizarAsync(Guid id, AvaliacaoUpdateDTO avaliacaoDTO)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoDTO);
            await _avaliacaoRepository.AtualizarAsync(id, avaliacao);
        }

        public async Task DeleteAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            await _avaliacaoRepository.DeleteAsync(avaliacao);
        }

        public async Task<AvaliacaoDTO> GetByIdAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            return _mapper.Map<AvaliacaoDTO>(avaliacao);
        }

        public async Task<AvaliacaoUpdateDTO> GetByIdUpdateAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<AvaliacaoUpdateDTO>(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoDTO>> GetAllAsync()
        {
            var avaliacao = await _avaliacaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AvaliacaoDTO>>(avaliacao);
        }
    }
}