using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IMensagemRepository
    {
        Task<Mensagem> AdicionarAsync(Mensagem mensagem);
        Task<Mensagem> AtualizarAsync(Guid id, Mensagem mensagem);
        Task<Mensagem> DeleteAsync(Mensagem mensagem);
        Task<Mensagem> GetByIdAsync(Guid id);
        Task<IEnumerable<Mensagem>> GetAllAsync();
    }
}