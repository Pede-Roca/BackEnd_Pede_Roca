using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Guid id, Categoria categoria);
        Task<Categoria> DeleteAsync(Categoria categoria);
        Task<Categoria> GetByIdAsync(Guid id);
        Task<IEnumerable<Categoria>> GetAllAsync();
    }
}
