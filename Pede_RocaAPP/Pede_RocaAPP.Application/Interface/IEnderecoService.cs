using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IEnderecoService
    {
        Task<Guid> AdicionarAsync(EnderecoCreateDTO categoriaDTO);
        Task AtualizarAsync(Guid id, EnderecoUpdateDTO categoriaDTO);
        Task DeleteAsync(Guid id);
        Task<EnderecoDTO> GetByIdAsync(Guid id);
        Task<EnderecoUpdateDTO> GetByIdUpdateAsync(Guid id);
        Task<EnderecoDTO> GetByUsuarioIdUpdateAsync(Guid id);
        Task<IEnumerable<EnderecoDTO>> GetAllAsync();
    }
}
