using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IComprasFinalizadasRepository
    {
        Task<ComprasFinalizadas> AdicionarAsync(ComprasFinalizadas finalizadas);
        Task<ComprasFinalizadas> AtualizarAsync(Guid id, ComprasFinalizadas finalizadas);
        Task<ComprasFinalizadas> DeleteAsync(ComprasFinalizadas finalizadas);
        Task<ComprasFinalizadas> GetByIdAsync(Guid id);
        Task<IEnumerable<ComprasFinalizadas>> GetAllAsync();
    }
}
