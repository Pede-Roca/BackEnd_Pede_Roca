using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(EnderecoCreateDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepository.AdicionarAsync(endereco);
            return endereco.Id;
        }

        public async Task AtualizarAsync(Guid id, EnderecoUpdateDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepository.AtualizarAsync(id, endereco);
        }

        public async Task DeleteAsync(Guid id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            await _enderecoRepository.DeleteAsync(endereco);
        }

        public async Task<EnderecoDTO> GetByIdAsync(Guid id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task<EnderecoUpdateDTO> GetByIdUpdateAsync(Guid id)
        {
            var endereco = await _enderecoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<EnderecoUpdateDTO>(endereco);
        }

        public async Task<EnderecoDTO> GetByUsuarioIdUpdateAsync(Guid id)
        {
            var endereco = await _enderecoRepository.GetByUsuarioIdUpdateAsync(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task<IEnumerable<EnderecoDTO>> GetAllAsync()
        {
            var enderecos = await _enderecoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EnderecoDTO>>(enderecos);
        }
    }
}