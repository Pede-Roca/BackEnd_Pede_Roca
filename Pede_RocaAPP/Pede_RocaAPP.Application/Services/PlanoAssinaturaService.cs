using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class PlanoAssinaturaService : IPlanoAssinaturaService
    {
        private readonly IMapper _mapper;

        private readonly IPlanoAssinaturaRepository _PlanoAssinaturarepository;

        public PlanoAssinaturaService(IPlanoAssinaturaRepository planoAssinaturarepository, IMapper mapper)
        {
            _mapper = mapper;
            _PlanoAssinaturarepository = planoAssinaturarepository;
        }

        public async Task AdicionarAsync(PlanoAssinaturaDTO planoAssinaturaDTO)
        {
            var planoAssinatura = _mapper.Map<PlanoAssinatura>(planoAssinaturaDTO);
            await _PlanoAssinaturarepository.AdicionarAsync(planoAssinatura);
        }

        public async Task AtualizarAsync(Guid id, PlanoAssinaturaDTO planoAssinaturaDTO)
        {
            var planoAssinatura = _mapper.Map<PlanoAssinatura>(planoAssinaturaDTO);
            await _PlanoAssinaturarepository.AtualizarAsync(id, planoAssinatura);
        }

        public async Task DeleteAsync(Guid id)
        {
            var planoAssinatura = await _PlanoAssinaturarepository.GetByIdAsync(id);
            await _PlanoAssinaturarepository.DeleteAsync(planoAssinatura);
        }

        public async Task<PlanoAssinaturaDTO> GetByIdAsync(Guid id)
        {
            var planoAssinatura = await _PlanoAssinaturarepository.GetByIdAsync(id);
            return _mapper.Map<PlanoAssinaturaDTO>(planoAssinatura);
        }

        public async Task<IEnumerable<PlanoAssinaturaDTO>> GetAllAsync()
        {
            var planosAssinaturas = await _PlanoAssinaturarepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlanoAssinaturaDTO>>(planosAssinaturas);
        }
    }
}
