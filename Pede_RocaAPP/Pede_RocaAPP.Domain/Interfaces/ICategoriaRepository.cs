using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Guid id, Categoria categoria);
        Task<Categoria> DeleteAsync(Categoria categoria);
        Task<Categoria> GetByIdAsync(Guid id);
        Task<Categoria> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<Produto>> GetByCategoriaIdAsync(Guid categoriaId);
        Task<IEnumerable<Categoria>> GetAllAsync();
    }
}
