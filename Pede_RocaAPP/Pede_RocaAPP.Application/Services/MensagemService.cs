using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class MensagemService : IMensagemService
    {
        private readonly IMapper _mapper;

        private readonly IMensagemRepository _mensagemRepository;

        public MensagemService(IMensagemRepository mensagemRepository, IMapper mapper)
        {
            _mensagemRepository = mensagemRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(MensagemDTO mensagemDTO)
        {
            var mensagem = _mapper.Map<Mensagem>(mensagemDTO);
            await _mensagemRepository.AdicionarAsync(mensagem);
        }

        public async Task AtualizarAsync(Guid id, MensagemDTO mensagemDTO)
        {
            var mensagem = _mapper.Map<Mensagem>(mensagemDTO);
            await _mensagemRepository.AtualizarAsync(id, mensagem);
        }

        public async Task DeleteAsync(Guid id)
        {
            var mensagem = await _mensagemRepository.GetByIdAsync(id);
            await _mensagemRepository.DeleteAsync(mensagem);
        }

        public async Task<MensagemDTO> GetByIdAsync(Guid id)
        {
            var mensagem = await _mensagemRepository.GetByIdAsync(id);
            return _mapper.Map<MensagemDTO>(mensagem);
        }

        public async Task<IEnumerable<MensagemDTO>> GetAllAsync()
        {
            var mensagens = await _mensagemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MensagemDTO>>(mensagens);
        }
    }
}