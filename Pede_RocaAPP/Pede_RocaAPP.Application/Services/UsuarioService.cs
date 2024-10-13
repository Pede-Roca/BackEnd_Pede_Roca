using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(UsuarioCreateDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.AdicionarAsync(usuario);
            return usuario.Id;
        }

        public async Task AtualizarAsync(Guid id, UsuarioDTO usuarioDTO)
        {
            // Primeiro, buscar o usu�rio existente no banco de dados
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usu�rio n�o encontrado");
            }

            // Atualize os campos do usu�rio existente com os dados do DTO
            usuarioExistente.Nome = usuarioDTO.Nome;
            usuarioExistente.Email = usuarioDTO.Email;
            usuarioExistente.Senha = usuarioDTO.Senha;
            usuarioExistente.DataNascimento = usuarioDTO.DataNasc;
            usuarioExistente.Telefone = usuarioDTO.Telefone;
            usuarioExistente.CPF = usuarioDTO.Cpf;
            usuarioExistente.UidFotoPerfil = usuarioDTO.UidFotoPerfil;

            // Outros campos que precisem ser atualizados

            // Agora que o objeto est� atualizado, envie para o reposit�rio
            await _usuarioRepository.AtualizarAsync(id, usuarioExistente);
        }

        public async Task AtualizarFotoPerfilAsync(Guid id, string uidFotoPerfil)
        {
            // Primeiro, buscar o usu�rio existente no banco de dados
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usu�rio n�o encontrado");
            }

            // Atualize o campo de foto de perfil
            usuarioExistente.UidFotoPerfil = uidFotoPerfil;
            
            // Agora que o objeto est� atualizado, envie para o reposit�rio
            await _usuarioRepository.AtualizarAsync(id, usuarioExistente);
        }
        


        public async Task DeleteAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<UsuarioDTO> GetByIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}