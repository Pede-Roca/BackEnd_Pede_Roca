using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IEnderecoService
    {
        Task AdicionarAsync(EnderecoDTO categoriaDTO);
        Task AtualizarAsync(Guid id, EnderecoDTO categoriaDTO);
        Task DeleteAsync(Guid id);
        Task<EnderecoDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<EnderecoDTO>> GetAllAsync();
    }
}
