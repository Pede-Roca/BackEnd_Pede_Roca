using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> AdicionarAsync(Avaliacao avaliacao);
        Task<Avaliacao> AtualizarAsync(Guid id, Avaliacao avaliacao);
        Task<Avaliacao> DeleteAsync(Avaliacao avaliacao);
        Task<Avaliacao> GetByIdAsync(Guid id);
        Task<IEnumerable<Avaliacao>> GetAllAsync();
    }
}