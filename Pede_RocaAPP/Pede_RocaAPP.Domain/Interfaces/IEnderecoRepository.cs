using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> AdicionarAsync(Endereco endereco);
        Task<Endereco> AtualizarAsync(Guid id, Endereco endereco);
        Task<Endereco> DeleteAsync(Endereco endereco);
        Task<Endereco> GetByIdAsync(Guid id);
        Task<IEnumerable<Endereco>> GetAllAsync();
    }
}