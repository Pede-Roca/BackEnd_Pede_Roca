using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IUsuarioService
    {
        Task<Guid> AdicionarAsync(UsuarioCreateDTO usuarioDTO);
        Task AtualizarAsync(Guid id, UsuarioDTO usuarioDTO);
        Task AtualizarFotoPerfilAsync(Guid id, string uidFotoPerfil);
        Task AtualizarStatusUsuarioAsync(Guid id, bool status);
        Task DeleteAsync(Guid id);
        Task<UsuarioDTO> GetByIdAsync(Guid id);
        Task<UsuarioDTO> GetByEmailAsync(string Email);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
    }
}