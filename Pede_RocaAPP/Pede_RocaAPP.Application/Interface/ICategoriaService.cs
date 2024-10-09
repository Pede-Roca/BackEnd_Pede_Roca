using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface ICategoriaService
    {
        Task<Guid> AdicionarAsync(CategoriaCreateDTO categoriaDTO);
        Task AtualizarAsync(Guid id, CategoriaCreateDTO categoriaDTO);
        Task DeleteAsync(Guid id);
        Task<CategoriaDTO> GetByIdAsync(Guid id);
        Task<CategoriaCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<Produto>> GetByCategoriaIdAsync(Guid id);
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
    }
}
