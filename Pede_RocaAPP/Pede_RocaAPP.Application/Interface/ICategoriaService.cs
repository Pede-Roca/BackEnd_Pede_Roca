using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface ICategoriaService
    {
        Task AdicionarAsync(CategoriaDTO categoriaDTO);
        Task AtualizarAsync(Guid id, CategoriaDTO categoriaDTO);
        Task DeleteAsync(Guid id);
        Task<CategoriaDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
    }
}
